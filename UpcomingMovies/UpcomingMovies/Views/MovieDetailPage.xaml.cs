using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UpcomingMovies.Models;
using UpcomingMovies.ViewModels;

namespace UpcomingMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        MovieDetailViewModel viewModel;

        public MovieDetailPage(MovieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public MovieDetailPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel;
        }
    }
}