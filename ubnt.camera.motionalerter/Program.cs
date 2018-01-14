using System;

using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;


using chad.home.ubnt.camera;



namespace ubnt.camera.motionalerter
{
    class Program
    {
        public static IConfigurationRoot Configuration;

        public static UbiquitiVideoManager _ubntManager;

        static void Main(string[] args)
        {
            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _ubntManager = new UbiquitiVideoManager(
                    Configuration.GetSection("UbiquitiNvrServer")["Address"],
                    Configuration.GetSection("UbiquitiNvrServer")["Key"]
                    );
            
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
        }

        public void GenerateAlert()
        {

        }
    }
}
