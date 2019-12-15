using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Xamarin.Essentials;

namespace TheMoviesApp
{
    public static class Startup
    {
        
        public static IServiceProvider ServiceProvider { get; set; }
        public static void Init()
        {
            var systemDir = FileSystem.CacheDirectory;
            var appSettings = $"{typeof(App).Namespace}.appsettings.json";
            AppServices.ExtractSaveResource(appSettings, systemDir);
            bool b = systemDir.Contains(appSettings);
            var fullConfig = Path.Combine(systemDir, appSettings);

            var host = new HostBuilder()
            .ConfigureHostConfiguration(c =>
            {
                // Tell the host configuration where to file the file (this is required for Xamarin apps)
                c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });

                //read in the configuration file!
                c.AddJsonFile(fullConfig);
            })
            .ConfigureServices((c, x) =>
            {
                // Configure our local services and access the host configuration
                ConfigureServices(c, x);
            })
            .ConfigureLogging(l => l.AddConsole(o =>
            {
                //setup a console logger and disable colors since they don't have any colors in VS
                o.DisableColors = true;
            }))
            .Build();

            //Save our service provider so we can use it later.
            ServiceProvider = host.Services;
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddAppServices(ctx.Configuration);
        }
        
    }
}
