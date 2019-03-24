using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using UpcomingMovies.Models;
using UpcomingMovies.Views;
using System.Linq;
using UpcomingMovies.Services.Interfaces;
using System.Collections.Generic;

namespace UpcomingMovies.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public Command LoadMoviesCommand { get; set; }

        private readonly IMoviesService _moviesService;

        public MoviesViewModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;

            Title = "Upcoming Movies";
            Movies = new ObservableCollection<Movie>();
            Genres = new ObservableCollection<Genre>();
            LoadMoviesCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if(Genres.Count == 0)
                    await LoadGenres();

                Movies.Clear();
                var movies = await _moviesService.GetUpcomingMovies();

                foreach (var movieResponse in movies.Results)
                {
                    var movie = new Movie()
                    {
                        Id = movieResponse.Id,
                        GenreIds = movieResponse.GenreIds,
                        Overview = movieResponse.Overview,
                        PosterPath = $"https://image.tmdb.org/t/p/original/{movieResponse.PosterPath}",
                        ReleaseDate = movieResponse.ReleaseDate,
                        Title = movieResponse.Title,
                        GenreNames = string.Empty,
                    };
                    movie.GenreIds.ForEach(id =>
                    {
                        movie.GenreNames = $"{movie.GenreNames} {Genres.FirstOrDefault(genre => genre.Id == id)?.Name},";
                    });
                    movie.GenreNames = movie.GenreNames.Substring(0, movie.GenreNames.Length - 1);
                    Movies.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task LoadGenres()
        {
            try
            {
                Genres.Clear();
                var genresResponse = await _moviesService.GetGenres();
                foreach (var genreResponse in genresResponse.Genres)
                {
                    var genre = new Genre()
                    {
                        Id = genreResponse.Id,
                        Name = genreResponse.Name,
                    };
                    Genres.Add(genre);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}