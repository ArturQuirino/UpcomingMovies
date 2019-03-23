using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Models.Responses;

namespace UpcomingMovies.ApiAccess.Refit
{
    public interface IMoviesRefit
    {
        [Get("/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US&page=1&region=us")]
        Task<MoviesResponse> GetUpcomingMovies();
        [Get("/genre/movie/list?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US")]
        Task<GenresResponse> GetGenres();
    }
}
