using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Models.Responses;

namespace UpcomingMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<MoviesResponse> GetUpcomingMovies();
        Task<GenresResponse> GetGenres();
    }
}
