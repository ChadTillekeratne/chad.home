using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json.Linq;

using System.Net;
using System.IO;

namespace chad.home.lametric
{

    public class LaMetricDevice
    {
        public string _ipAddress;
        public string _authorizationKey;    //TODO: Make this a SecureString

        public int _managementPort;
        
        public string _authorizationHeader; //TODO: Make this a SecureString


        public LaMetricDevice(String ipAddress, string authorizationKey, int port = 8080)
        {

            _ipAddress = ipAddress;
            _authorizationKey = authorizationKey;

            _managementPort = port;

            // Generate the authroization header
            _authorizationHeader = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", "dev", authorizationKey)));
        }


        #region Display

        public String Display
        {
            get
            {
                return HttpGet("/api/v2/device/display");
            }
        }

        #endregion

        #region Notifications

        // http://lametric-documentation.readthedocs.io/en/latest/reference-docs/device-notifications.html#display-notification
        /// POST api/v2/device/notifications
        //{
        //  "priority": "[info|warning|critical]",
        //  "icon_type":"[none|info|alert]",
        //  "lifeTime":< milliseconds >,
        //  "model": {
        //                    "frames": [
        //                     {
        //       "icon":"<icon id or base64 encoded binary>",
        //                        "text":"<text>"
        //    },
        //    {
        //      "icon":"i298",
        //      "text":"text"
        //    },
        //    {
        //        "icon":"i120",
        //        "goalData":{
        //            "start": 0,
        //            "current": 50,
        //            "end": 100,
        //            "unit": "%"
        //        }
        //    },
        //    {
        //        "chartData": [ <comma separated integer values> ]
        //    }
        //    ],
        //    "sound": {
        //      "category":"[alarms|notifications]",
        //        "id":"<sound_id>",
        //        "repeat":<repeat count>
        //    },
        //    "cycles":<cycle count>
        //  }
        //}

        //JObject j =
        //        new JObject(
        //        new JProperty("frames",
        //            new JArray(
        //                new JObject(
        //                new JProperty("text", JObject.Parse(s)["numFollowers"]),
        //                new JProperty("icon", "i15752")
        //                )
        //            )
        //        )
        //    );

        public void SendNotification(String message, String priority)
        {
            //TODO: Generate the notifcation configuration

            JObject jj =
                new JObject(
                    new JProperty("priority", "info"),
                    new JProperty("icon_type", "none"),
                    new JProperty("lifeTime", "1000"),
                    new JProperty("model",
                        new JObject(
                            new JProperty("cycles", "2"),
                            new JProperty("frames",
                                new JArray(
                                    new JObject(
                                        new JProperty("icon", "i15752"),
                                        new JProperty("text", "Hello")
                                        ),
                                    new JObject(
                                        new JProperty("icon", "i15752"),
                                        new JProperty("text", "World")
                                        ),
                                    new JObject(
                                        new JProperty("chartData",
                                            new JArray(new int[] { 1, 1, 2, 3, 4, 5, 10, 2, 4 })
                                            )
                                        )
                                    )
                            ),
                            new JProperty("sound",
                                new JObject(
                                    new JProperty("category", "notifications"),
                                    new JProperty("id", "negative5"),
                                    new JProperty("repeat", "1")
                                    )
                                )
                            )
                        )
                    );


            String s = HttpPost(@"/api/v2/device/notifications", jj.ToString());
        }

        #endregion

        #region Http Helpers

        private WebRequest CreateLaMetricWebRequest(String api)
        {
            String uriRoot = String.Format("http://{0}:{1}/", _ipAddress, _managementPort);

            WebRequest request = WebRequest.Create(uriRoot + "/" + api);

            request.Headers.Add("Authorization", "Basic " + _authorizationHeader);
            request.Headers.Add("Accept", "application/json");

            return request;
        }

        private string HttpGet(String api)
        {
            WebRequest request = CreateLaMetricWebRequest(api);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }

        }

        private string HttpPost(String api, String postData)
        {
            WebRequest request = CreateLaMetricWebRequest(api);

            Byte[] postBytes = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(postBytes, 0, postBytes.Length);
            dataStream.Close();

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }

        }

        #endregion
    }

   
}
