using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;
using System.IO;

using chad.home.lametric;


namespace lametric.console
{
    class Program
    {
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            //Configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();


            LaMetricDevice lametric = new LaMetricDevice(
                Configuration.GetSection("LaMetricDevice")["IpAddress"],
                Configuration.GetSection("LaMetricDevice")["ApplicationKey"]
                );

            //Console.WriteLine(lad.Display);

            lametric.SendNotification("Testing 123", "info");

        }
    }
}
