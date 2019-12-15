using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMoviesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheMoviesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<MoviesViewModel>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MoviesViewModel)BindingContext).DoIt();
        }
    }
}