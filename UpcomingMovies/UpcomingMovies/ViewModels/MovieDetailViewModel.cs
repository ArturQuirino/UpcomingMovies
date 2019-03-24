using System;

using UpcomingMovies.Models;

namespace UpcomingMovies.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel
    {
        public Movie Item { get; set; }
        public MovieDetailViewModel(Movie item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
