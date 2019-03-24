using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UpcomingMovies.Models;
using UpcomingMovies.Views;
using UpcomingMovies.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace UpcomingMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            InitializeComponent();
            BindingContext = ServiceLocator.Current.GetInstance<MoviesViewModel>();
        }

        public MoviesViewModel MoviesViewModel
        {
            get
            {
                return (MoviesViewModel)BindingContext;
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Movie item = args.SelectedItem as Movie;
            if (item == null)
                return;

            await Navigation.PushAsync(new MovieDetailPage(new MovieDetailViewModel(item)));

            // Manually deselect item.
            MoviesListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (MoviesViewModel.Movies.Count == 0)
                MoviesViewModel.LoadMoviesCommand.Execute(null);
            
        }
    }
}