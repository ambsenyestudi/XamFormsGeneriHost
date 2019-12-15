using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TheMoviesApp.Core.Movies;
using TheMoviesApp.ViewModels;

namespace TheMoviesApp
{
    public static class AppServices
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGateways(configuration)
                .AddServices()
                .addViewModels();
        }
        public static IServiceCollection AddGateways(this IServiceCollection services, IConfiguration configuration)
        {
            var moviesConfig = configuration.GetSection("Movies");
            services.Configure<MoviesOptions>(moviesConfig);
            services.AddHttpClient<IMoviesGateway, MoviesGateway>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IMoviesService, MoviesService>();
            return services;
        }
        public static IServiceCollection addViewModels(this IServiceCollection services)
        {
            services.AddTransient<MoviesViewModel>();
            return services;
        }
        public static void ExtractSaveResource(string filename, string location)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }

                }
            }
        }
        public static string GetNameSpace(this Type type)
        {
            return type.Namespace;
        }
    }
}
