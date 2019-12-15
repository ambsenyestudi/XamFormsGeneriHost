using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheMoviesApp.Core.Movies
{
    public interface IMoviesGateway
    {
        Task<IEnumerable<SearchedMovie>> SearchMovieByTitle(string title = "star");
    }
}
