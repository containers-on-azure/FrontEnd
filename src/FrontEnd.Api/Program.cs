using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrontEnd.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            // need to check both environment variables for now
            // https://github.com/dotnet/dotnet-docker/issues/677
            var inContainer =
                (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true") ||
                (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINERS") == "true");

            if (!inContainer)
            {                
                builder.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile($"appsettings.{env.EnvironmentName}.NotInContainer.json", optional: true, reloadOnChange: true);
                });
            }
                
                    
            return builder.UseStartup<Startup>();
        }
    }
}
