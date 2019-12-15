using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheMoviesApp.Core.Movies
{
    public interface IMoviesService
    {
        void DoStuff();
        Task<IEnumerable<Movie>> GetMoviesAsync();
    }
}
