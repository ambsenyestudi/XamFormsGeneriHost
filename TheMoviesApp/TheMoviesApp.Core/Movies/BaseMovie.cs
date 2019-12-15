using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMoviesApp.Core.Movies
{
    public class BaseMovie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        [JsonProperty("Poster")]
        public string PosterUrl { get; set; }
    }
}
