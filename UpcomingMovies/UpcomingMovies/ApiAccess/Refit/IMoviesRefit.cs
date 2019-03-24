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
        [Get("/movie/upcoming?api_key={apiKey}&language={language}&page={page}&region={region}")]
        Task<MoviesResponse> GetUpcomingMovies(
            [AliasAs("apikey")]string apikey,
            [AliasAs("page")]string page,
            [AliasAs("language")]string language = "en-US",
            [AliasAs("region")]string region = "us"
        );
        [Get("/genre/movie/list?api_key={apiKey}&language={language}")]
        Task<GenresResponse> GetGenres(
            [AliasAs("apikey")]string apikey,
            [AliasAs("language")]string language = "en-US"
        );
    }
}
