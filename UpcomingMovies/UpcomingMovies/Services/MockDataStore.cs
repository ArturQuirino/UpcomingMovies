using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UpcomingMovies.Models;
using UpcomingMovies.Services.Responses;

namespace UpcomingMovies.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        List<Movie> items;

        HttpClient client;

        public MockDataStore()
        {
            items = new List<Movie>();
            var mockItems = new List<Movie>
            {
                new Movie{ Id = 450001, PosterPath = "/grtVFGJ4ts0nDAPpc1JWbBoVKTu.jpg", GenreIds = new List<int>(){28}, ReleaseDate = "2018-12-20", Title = "Master Z: Ip Man Legacy"},
                new Movie{ Id = 450001, PosterPath = "/grtVFGJ4ts0nDAPpc1JWbBoVKTu.jpg", GenreIds = new List<int>(){28}, ReleaseDate = "2018-12-20", Title = "Master Z: Ip Man Legacy"},
                new Movie{ Id = 450001, PosterPath = "/grtVFGJ4ts0nDAPpc1JWbBoVKTu.jpg", GenreIds = new List<int>(){28}, ReleaseDate = "2018-12-20", Title = "Master Z: Ip Man Legacy"},
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<bool> AddItemAsync(Movie item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Movie item)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(true);
        }

        public async Task<Movie> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var uri = new Uri("https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US&page=1&region=us");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var moviesResponse = JsonConvert.DeserializeObject<MoviesResponse>(content);
                    items = new List<Movie>();
                    moviesResponse.results.ForEach(movie => items.Add(new Movie()
                    {
                        Id = movie.Id,
                        GenreIds = movie.GenreIds,
                        Overview = movie.Overview,
                        PosterPath = movie.PosterPath,
                        ReleaseDate = movie.ReleaseDate,
                        Title = movie.Title,
                    }));
                }
            }
            catch (Exception ex)
            {
                //Log Expection ex
                items = new List<Movie>();
            }
            
            return await Task.FromResult(items);
        }
    }
}