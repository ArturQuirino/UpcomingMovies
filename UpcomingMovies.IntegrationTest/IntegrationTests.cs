using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpcomingMovies.Services.Implementations;
using UpcomingMovies.ViewModels;

namespace UpcomingMovies.IntegrationTest
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public async Task TestGetUpcomingMovies()
        {
            MoviesService moviesService = new MoviesService();

            MoviesViewModel moviesViewModel = new MoviesViewModel(moviesService);

            await moviesViewModel.ExecuteLoadItemsCommand();

            Assert.IsTrue(moviesViewModel.Movies.Count > 0);
            Assert.IsTrue(moviesViewModel.Genres.Count > 0);
        }

        [TestMethod]
        public async Task TestGetGenres()
        {
            MoviesService moviesService = new MoviesService();

            MoviesViewModel moviesViewModel = new MoviesViewModel(moviesService);

            await moviesViewModel.LoadGenres();
            
            Assert.IsTrue(moviesViewModel.Genres.Count > 0);
        }
    }
}
