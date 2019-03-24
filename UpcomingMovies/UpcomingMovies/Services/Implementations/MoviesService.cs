using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Models.Responses;
using UpcomingMovies.Repositories;
using UpcomingMovies.Services.Interfaces;

namespace UpcomingMovies.Services.Implementations
{
    public class MoviesService : IMoviesService
    {
        public async Task<MoviesResponse> GetUpcomingMovies(int page)
        {
            return await MoviesRepository.Get().GetUpcomingMovies(page);
        }

        public async Task<GenresResponse> GetGenres()
        {
            return await MoviesRepository.Get().GetGenres();
        }
        
    }
}
