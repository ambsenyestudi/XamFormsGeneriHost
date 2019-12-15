using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TheMoviesApp.Core;
using TheMoviesApp.Core.Movies;
using Xamarin.Forms;

namespace TheMoviesApp.ViewModels
{
    public class SearchViewModel:BaseViewModel
    {
        private readonly IMoviesService movieService;
        private readonly INavigationService navigationService;
        

        public SearchViewModel(IMoviesService movieService, INavigationService navigationService)
        {
            this.movieService = movieService;
            this.navigationService = navigationService;
            MovieCollection = new List<SearchedMovie>();
            BackCommand = new Command(() => navigationService.PopModalAsync());
            SeachCommand = new Command(SerachMovies);
        }
        private string searchingTitle;

        public string SearchingTitle
        {
            get => searchingTitle; 
            set 
            { 
                searchingTitle = value;
                OnPropertyChanged();
            }
        }

        private ICommand backCommand;
        public ICommand BackCommand 
        { 
            get => backCommand;
            set
            {
                backCommand = value;
                OnPropertyChanged();
            } 
        }

        private ICommand seachCommand;

        public ICommand SeachCommand
        {
            get =>seachCommand; 
            set 
            { 
                seachCommand = value;
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
        private async void SerachMovies(object obj)
        {
            var movieCollection = await movieService.SearchMovieByTitle(SearchingTitle);
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
