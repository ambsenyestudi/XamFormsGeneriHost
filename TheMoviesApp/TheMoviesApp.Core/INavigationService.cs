using System.Threading.Tasks;

namespace TheMoviesApp.Core
{
    public interface INavigationService
    {
        Task ShowSearchModalAsync();
        Task PopModalAsync();
    }
}
