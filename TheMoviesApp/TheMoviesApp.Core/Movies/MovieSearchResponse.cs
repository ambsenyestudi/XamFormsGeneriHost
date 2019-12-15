using System.Collections.Generic;

namespace TheMoviesApp.Core.Movies
{
    public class MovieSearchResponse
    {
        public IEnumerable<SearchedMovie> Search { get; set; }
    }
}
