using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheMoviesApp.Core.Movies
{
    public class MoviesService : IMoviesService
    {
        private readonly ILogger<MoviesService> logger;
        private readonly IMoviesGateway gateway;

        public MoviesService(IMoviesGateway gateway, ILogger<MoviesService> logger)
        {
            this.logger = logger;
            this.gateway = gateway;
        }
        public void DoStuff()
        {
            logger.LogCritical($"You just called DoStuff from {this.GetType().Name}");
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return gateway.GetMoviesAsync();
        }
    }
}
