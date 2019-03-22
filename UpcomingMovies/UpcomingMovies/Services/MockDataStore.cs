using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMovies.Models;

namespace UpcomingMovies.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        List<Movie> items;

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
            return await Task.FromResult(items);
        }
    }
}