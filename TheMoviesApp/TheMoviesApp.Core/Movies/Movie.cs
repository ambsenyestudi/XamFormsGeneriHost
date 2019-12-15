using Newtonsoft.Json;

namespace TheMoviesApp.Core.Movies
{
    public class Movie
    {
        public string Title { get; set; }
        public string Released { get; set; }
        public string Plot { get; set; }
        public string Year { get; set; }
        //todo, gets list coma separated
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        [JsonProperty("Poster")]
        public string PosterUrl { get; set; }
    }
}
