using System;

using chad.home.ubnt.camera;

namespace ubnt.camera.motionalerter
{
    class Program
    {
        public static UbiquitiVideoManager _ubntManager;

        static void Main(string[] args)
        {
            //TODO: Load variables from config
            _ubntManager = new UbiquitiVideoManager("home.chad.cc", "GgbpmIvEVMV1TQxm");
            //_ubntManager = new UbiquitiVideoManager("192.168.1.100", "GgbpmIvEVMV1TQxm");


            _ubntManager.OnMotionDetected += _ubntManager_OnMotionDetected;
            _ubntManager.OnMotionStopped += _ubntManager_OnMotionStopped;

            var r = _ubntManager.StartMotionDetection(10);

            Console.WriteLine("Motion Monitoring is {0} on is {1} cameras; {2}",r.RecordingActive ? "ACTIVE" : "FAILED", r.RecordingCameras.Length, r.ErrorText);

            System.Threading.Thread.Sleep(10*60*1000);

            _ubntManager.StopMotionDetection();

            Console.WriteLine("Monitoring has timed out");

        }

        private static void _ubntManager_OnMotionStopped(object sender, MotionStoppedEventArgs e)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Motion Stopped : {0} : {1} : {2} : {3}", e.Recording.data[0].cameras[0], e.Recording.data[0]._id, e.Recording.data[0].startTime, e.Recording.data[0].endTime);

            Console.ResetColor();
        }

        private static void _ubntManager_OnMotionDetected(Object o, MotionDetectedEventArgs e)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Motion Detected : {0} : {1} : {2} : {3}",e.Camera.Id,e.Camera.Name, e.Camera.LastRecordingStartTime, e.Camera.LastRecordingId);

            Console.ResetColor();
            this.
        }

        public void GenerateAlert()
        {

        }
    }
}
