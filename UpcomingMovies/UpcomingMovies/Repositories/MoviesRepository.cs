using Polly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.ApiAccess;
using UpcomingMovies.ApiAccess.Refit;
using UpcomingMovies.Models.Responses;
using UpcomingMovies.Utils;

namespace UpcomingMovies.Repositories
{
    public class MoviesRepository
    {
        private static MoviesRepository _instance;
        public static MoviesRepository Get()
        {
            if (_instance == null)
                _instance = new MoviesRepository();

            return _instance;
        }

        public async Task<MoviesResponse> GetUpcomingMovies(int page)
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await MoviesApiAcess.GetClientApi<IMoviesRefit>().GetUpcomingMovies(Constants.API_KEY, page.ToString())
              );

            return response;
        }

        public async Task<GenresResponse> GetGenres()
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await MoviesApiAcess.GetClientApi<IMoviesRefit>().GetGenres(Constants.API_KEY)
              );

            return response;
        }
    }
}
