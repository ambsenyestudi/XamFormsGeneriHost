
using TheMoviesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheMoviesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            BindingContext = Startup.ServiceProvider.GetService<MoviesViewModel>();
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MoviesViewModel)BindingContext).DoIt();
        }
    }
}