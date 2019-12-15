using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheMoviesApp.Core.Movies
{
    public class MoviesGateway : IMoviesGateway
    {

        private readonly MoviesOptions options;
        private readonly HttpClient httpClient;
        private readonly ILogger<MoviesGateway> logger;
        public const string TITLE_SEARCH_TEMPLATE = "?s={0}&apikey={1}";

        public MoviesGateway(HttpClient httpClient, IOptions<MoviesOptions> options, ILogger<MoviesGateway> logger)
        {
            this.options = options.Value;
            this.httpClient = httpClient;
            this.logger = logger;
            Init();
        }

        private void Init()
        {
            httpClient.BaseAddress = new Uri(options.BaseUrl);
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync(string title = "star")
        {
            string method = string.Format(TITLE_SEARCH_TEMPLATE, title, options.ApiKey);
            string msg = $"[{this.GetType().Name}] getting movies at {options.BaseUrl}{method}";
            logger.LogInformation(msg);

            return GetMoviesDeserializedAsync(method);
        }

        private async Task<string> GetAsync(string method)
        {
            var response = await httpClient.GetAsync(method);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IEnumerable<Movie>> GetMoviesDeserializedAsync(string method)
        {
            var serialized = await GetAsync(method);
            var searchResult = JsonConvert.DeserializeObject<MovieSearch>(serialized);
            return searchResult.Search;
        }

    }
}
