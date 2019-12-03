using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore;
using Newtonsoft.Json.Linq;

namespace curd
{
    public class Program
    {
        public static void Main(string[] args)
        {

          

            /* var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
             var pathToContentRoot = Path.GetDirectoryName(pathToExe);

             var host = WebHost.CreateDefaultBuilder(args)
                 .UseContentRoot(pathToContentRoot)
                 .UseStartup<Startup>()
                 .Build();

             host.RunAsService();*/

            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
                // Enable NLog as one of the Logging Provider
                logging.AddNLog();
            }).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
