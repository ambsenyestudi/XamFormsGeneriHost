﻿using System.Collections.Generic;
using System.Linq;
using TheMoviesApp.Core.Movies;

namespace TheMoviesApp.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private IMoviesService movieService;

        public MoviesViewModel(IMoviesService movieService)
        {
            this.movieService = movieService;
        }
        private IEnumerable<Movie> movieCollection;

        public IEnumerable<Movie> MovieCollection
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
            var movieCollection = await movieService.GetMoviesAsync();
            if (movieCollection.Any())
            {
                MovieCollection = movieCollection;
            }
            else
            {
                MovieCollection = new List<Movie>();
            }
        }
    }
}
