using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HosteliteAPI
{
    /// <summary>
    /// This class is responsible for building and starting up our application on the web browser via a IIS Express server
    /// </summary>
    /// <returns></returns>
    public class Program
    {
        /// <summary>
        /// This method instantiates the building our of app
        /// </summary>
        /// <returns></returns>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This class bootstraps the startup class to startup and host our app for access in the browser
        /// </summary>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
