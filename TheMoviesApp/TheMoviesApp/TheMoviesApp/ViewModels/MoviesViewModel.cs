using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TheMoviesApp.Core;
using TheMoviesApp.Core.Movies;
using TheMoviesApp.Views;
using Xamarin.Forms;

namespace TheMoviesApp.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private IMoviesService movieService;

        public MoviesViewModel(IMoviesService movieService, INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.movieService = movieService;
            
            SearchCommand = new Command(() =>
            {
                navigationService.ShowSearchModalAsync();
                //App.Current.MainPage.Navigation.PushModalAsync(new SearchPage());
            });
            
        }

        private ICommand searchCommand;

        public ICommand SearchCommand
        {
            get => searchCommand; 
            set 
            { 
                searchCommand = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<SearchedMovie> movieCollection;

        public IEnumerable<SearchedMovie> MovieCollection
        {
            get => movieCollection;
            set
            {
                movieCollection = value;
                OnPropertyChanged();
            }
        }


        public void DoIt()
        {
            movieService.DoStuff();
            InitMovies();
        }
        public async void InitMovies()
        {
            var movieCollection = await movieService.SearchMovieByTitle();
            if (movieCollection.Any())
            {
                MovieCollection = movieCollection;
            }
            else
            {
                MovieCollection = new List<SearchedMovie>();
            }
        }
    }
}
