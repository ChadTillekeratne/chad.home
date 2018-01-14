using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Security;

using System.Net;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.ComponentModel;

namespace chad.home.ubnt.camera
{
    public class UbiquitiVideoManager : IDisposable
    {
        #region Events
        
        public delegate void MotionDetected(Object sender, MotionDetectedEventArgs e);
        public delegate void MotionStopped(Object sender, MotionStoppedEventArgs e);


        public event MotionDetected OnMotionDetected;
        public event MotionStopped OnMotionStopped;
        
        
        //public event EventHandler CameraDisconnected;

        #endregion

        #region Global Variables

        private static String _nvrServerAddress;
        private static int _nvrServerPort;
        private static String _nvrApiKey;   //TODO: Make this a SecureString

        private static Dictionary<string, Object> _lastSampledRecordings = new Dictionary<string, Object>();

        private BackgroundWorker _workerMotionWatcher = new BackgroundWorker();

        #endregion

        #region Constructors

        // Api Key
        public UbiquitiVideoManager(String nvrServerAddress, String nvrApiKey, int nvrServerPort = 7443)
        {
            InitializeSharedVariables(nvrServerAddress, nvrServerPort);

            _nvrApiKey = nvrApiKey;
        }

        // Username:Password
        public UbiquitiVideoManager(String nvrServerAddress, String nvrUsername, SecureString nvrPassword, int nvrServerPort = 7443)
        {
            InitializeSharedVariables(nvrServerAddress, nvrServerPort);

            //TODO: Initialize Username:Password Credentials

        }
        
        public  void InitializeSharedVariables(String nvrServerAddress, int nvrServerPort = 7443)
        {
            _nvrServerAddress = nvrServerAddress;
            _nvrServerPort = nvrServerPort;

            _workerMotionWatcher.DoWork += _workerMotionWatcher_DoWork;
            _workerMotionWatcher.WorkerSupportsCancellation = true;
        }

        #endregion

        #region Properties

        public UbiquitiCamera[] Camera
        {
            get
            {
                return GetCameras();
            }
        }

        //public Object[] Recordings
        //{
        //    get
        //    {
        //        return new Object[0];
        //    }
        //}

        #endregion

        #region Detect Motion

        public StartMotionDetectionResult StartMotionDetection(int pollingIntervalSeconds = 10)
        {
            var allCams = Camera;
            var recordingCameras = allCams.Where(a => a.recordingSettings.motionRecordEnabled == true && a.State.ToUpper() == "CONNECTED");
            
            if(recordingCameras.Count() > 0)
                _workerMotionWatcher.RunWorkerAsync(pollingIntervalSeconds);

            return new StartMotionDetectionResult
            {
                RecordingCameras = recordingCameras.ToArray(),
                RecordingActive = (recordingCameras.Count() > 0),
                ErrorText = (allCams.Count() > 0) ? ((recordingCameras.Count() > 0) ? null : "There are no 'CONNECTED' cameras with motion record enabled") : "DVR has no cameras"
                };
        }
        

        private void _workerMotionWatcher_DoWork(object sender, DoWorkEventArgs e)
        {
            while (1 == 1)
            {
                foreach (var c in this.Camera)
                {
                    if (c.recordingSettings.motionRecordEnabled)    //motion detection requires motionRecording
                    {
                        String cacheRecordingIsActiveKey = String.Format("{0}-{1}", c.Id, "RecordingInProgress");

                        if (_lastSampledRecordings.ContainsKey(c.Id) && c.LastRecordingStartTime > (DateTime)_lastSampledRecordings[c.Id])
                        {
                            if (OnMotionDetected != null)
                                OnMotionDetected(null, new MotionDetectedEventArgs { Camera = c });
                        }

                        // Update the recording cache
                        _lastSampledRecordings[c.Id] = c.LastRecordingStartTime;

                        if (_lastSampledRecordings.ContainsKey(cacheRecordingIsActiveKey))
                        {
                            if ((Boolean)_lastSampledRecordings[cacheRecordingIsActiveKey] == true && c.LastRecording.data[0].inProgress == false)
                            {
                                // Recording has stopped: was recordingActive, now recordingNotActive
                                if (OnMotionStopped != null)
                                    OnMotionStopped(null, new MotionStoppedEventArgs { Recording = c.LastRecording });
                            }
                        }

                        // Update the cache
                        _lastSampledRecordings[cacheRecordingIsActiveKey] = c.LastRecording.data[0].inProgress;  //TODO: Multiple data?
                    } 
                }

                System.Threading.Thread.Sleep(int.Parse(e.Argument.ToString()) * 1000);

            }
        }

        protected NvrRecording GetRecording(String recordingId)
        {
            String s = HttpGet(String.Format("recording/{0}", recordingId));

            return JsonConvert.DeserializeObject<NvrRecording>(s);
        }
        
        public void StopMotionDetection()
        {
            _workerMotionWatcher.CancelAsync();
        }

        #endregion

        #region Camera

        private UbiquitiCamera[] GetCameras()
        {
            List<UbiquitiCamera> cameras = new List<UbiquitiCamera>();

            String s = HttpGet("camera");
            JObject r = JObject.Parse(s);

            // Manually create objects
            foreach (var c in ((JArray)r["data"]))
            {
                // Foreach camera
                //UbiquitiCamera cam = new UbiquitiCamera();

                UbiquitiCamera cam = JsonConvert.DeserializeObject<UbiquitiCamera>(c.ToString());

                //cam.Id = c["_id"].ToString();
                //cam.Name = c["name"].ToString();
                //cam.Model = c["model"].ToString();
                //cam.LastRecordingStartTime = Util.FromUnixTime(long.Parse(c["lastRecordingStartTime"].ToString())).ToLocalTime(); //TODO: null value?
                //cam.LastRecordingId = c["lastRecordingId"].ToString();
                //cam.State = c["state"].ToString();

                cam.LastRecording = GetRecording(c["lastRecordingId"].ToString());

                cameras.Add(cam);
            }

            return cameras.ToArray();
        }

        #endregion 

        #region Recordings
        
        private String GetRecordings()
        {
            //Filter: Camera, String 
            throw new NotImplementedException();
        }

        #endregion  

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #region Helpers


        #region Helpers: HTTP
        private WebRequest CreateUbiquitiVideoWebRequest(String api)
        {
            String uriRoot = String.Format("https://{0}:{1}/api/2.0", _nvrServerAddress, _nvrServerPort);
            String requestUri = uriRoot + "/" + api;
            
            // Add authentication
            if (_nvrApiKey != null && _nvrApiKey != String.Empty)
            {
                // API Authentication
                requestUri = requestUri + "?apiKey=" + _nvrApiKey;  //TODO: Check if there are existing querystring variables, validate format
            }
            else 
            {
                //TODO: Validate basic auth
            }

            WebRequest request = WebRequest.Create(requestUri);
            
            // Disable HTTPS validation
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // Always accept
                    };

            return request;
        }

        private string HttpGet(String api)
        {
            WebRequest request = CreateUbiquitiVideoWebRequest(api);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }

        }

        //private string HttpPost(String api, String postData)
        //{
        //    WebRequest request = CreateUbiquitiVideoWebRequest(api);

        //    Byte[] postBytes = Encoding.UTF8.GetBytes(postData);

        //    request.Method = "POST";
        //    Stream dataStream = request.GetRequestStream();
        //    dataStream.Write(postBytes, 0, postBytes.Length);
        //    dataStream.Close();

        //    using (WebResponse response = request.GetResponse())
        //    {
        //        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}
        #endregion

        #endregion

        #region Diagnostics

        protected Byte[] GetDiagnosticsDump()
        {
            //TODO: Make a lot of calls to the API, dump logs


            throw new NotImplementedException();
        }


        #endregion
    }


    public class MotionDetectedEventArgs : EventArgs
    {
        public UbiquitiCamera Camera;

    }

    public class MotionStoppedEventArgs : EventArgs
    {
        public NvrRecording Recording;
    }

    public struct StartMotionDetectionResult
    {
        public Boolean RecordingActive { get; set; }
        public UbiquitiCamera[] RecordingCameras { get; set; }

        public String ErrorText { get; set; }
    }
}
