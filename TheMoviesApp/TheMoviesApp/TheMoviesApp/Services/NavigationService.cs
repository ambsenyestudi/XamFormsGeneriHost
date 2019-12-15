using System.Threading.Tasks;
using TheMoviesApp.Core;
using TheMoviesApp.Views;
using Xamarin.Forms;

namespace TheMoviesApp.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation navigation;
        public INavigation Navigation 
        { 
            get 
            { 
                if(navigation == null)
                {
                    navigation = App.Current.MainPage.Navigation;
                }
                return navigation;
            } 
        }

        public Task ShowSearchModalAsync() => 
            Navigation.PushModalAsync(new SearchPage());

        public Task PopModalAsync()=> 
            Navigation.PopModalAsync();
        
    }
}
