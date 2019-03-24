using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UpcomingMovies.Models.Responses;
using UpcomingMovies.Services.Interfaces;
using UpcomingMovies.ViewModels;

namespace UpcomingMovies.UnitTests
{
    [TestClass]
    public class UnitTestMovies
    {
        [TestMethod]
        public async Task TestGetUpcomingMovies()
        {
            Mock<IMoviesService> moviesServiceMock = new Mock<IMoviesService>();
            MoviesResponse moviesResponse = new MoviesResponse()
            {
                TotalPages = 1,
                Page = 1,
                TotalResults = 1,
                Results = new List<MovieResponse>()
                {
                    new MovieResponse()
                    {
                        Id = 1,
                        GenreIds = new List<int>(){1,2},
                        Overview = "This is a movie",
                        PosterPath = "moviepath.jpg",
                        ReleaseDate = "2019-03-24",
                        Title = "My movie"
                    },
                    new MovieResponse()
                    {
                        Id = 2,
                        GenreIds = new List<int>(){1,2},
                        Overview = "This is a movie 2",
                        PosterPath = "movie2path.jpg",
                        ReleaseDate = "2019-03-24",
                        Title = "My movie2"
                    }
                }
            };

            GenresResponse genresResponse = new GenresResponse()
            {
                Genres = new List<GenreResponse>()
                {
                    new GenreResponse()
                    {
                        Id = 1,
                        Name = "Action"
                    },
                    new GenreResponse()
                    {
                        Id = 2,
                        Name = "Comedy"
                    }
                }
            };

            moviesServiceMock.Setup(s => s.GetUpcomingMovies(It.IsAny<int>())).Returns(Task.FromResult(moviesResponse));

            moviesServiceMock.Setup(s => s.GetGenres()).Returns(Task.FromResult(genresResponse));

            MoviesViewModel moviesViewModel = new MoviesViewModel(moviesServiceMock.Object);

            await moviesViewModel.ExecuteLoadItemsCommand();

            Assert.IsTrue(moviesViewModel.Movies.Count == 2);
        }

        [TestMethod]
        public async Task TestGetGenres()
        {
            Mock<IMoviesService> moviesServiceMock = new Mock<IMoviesService>();

            GenresResponse genresResponse = new GenresResponse()
            {
                Genres = new List<GenreResponse>()
                {
                    new GenreResponse()
                    {
                        Id = 1,
                        Name = "Action"
                    },
                    new GenreResponse()
                    {
                        Id = 2,
                        Name = "Comedy"
                    }
                }
            };

            moviesServiceMock.Setup(s => s.GetGenres()).Returns(Task.FromResult(genresResponse));

            MoviesViewModel moviesViewModel = new MoviesViewModel(moviesServiceMock.Object);

            await moviesViewModel.LoadGenres();

            Assert.IsTrue(moviesViewModel.Genres.Count == 2);
        }

        [TestMethod]
        public async Task TestGetUpcomingMoviesMoreThanOnePage()
        {
            Mock<IMoviesService> moviesServiceMock = new Mock<IMoviesService>();
            MoviesResponse moviesResponse = new MoviesResponse()
            {
                TotalPages = 2,
                Page = 1,
                TotalResults = 4,
                Results = new List<MovieResponse>()
                {
                    new MovieResponse()
                    {
                        Id = 1,
                        GenreIds = new List<int>(){1,2},
                        Overview = "This is a movie",
                        PosterPath = "moviepath.jpg",
                        ReleaseDate = "2019-03-24",
                        Title = "My movie"
                    },
                    new MovieResponse()
                    {
                        Id = 2,
                        GenreIds = new List<int>(){1,2},
                        Overview = "This is a movie 2",
                        PosterPath = "movie2path.jpg",
                        ReleaseDate = "2019-03-24",
                        Title = "My movie2"
                    }
                }
            };

            GenresResponse genresResponse = new GenresResponse()
            {
                Genres = new List<GenreResponse>()
                {
                    new GenreResponse()
                    {
                        Id = 1,
                        Name = "Action"
                    },
                    new GenreResponse()
                    {
                        Id = 2,
                        Name = "Comedy"
                    }
                }
            };

            moviesServiceMock.Setup(s => s.GetUpcomingMovies(It.IsAny<int>())).Returns(Task.FromResult(moviesResponse));

            moviesServiceMock.Setup(s => s.GetGenres()).Returns(Task.FromResult(genresResponse));

            MoviesViewModel moviesViewModel = new MoviesViewModel(moviesServiceMock.Object);

            await moviesViewModel.ExecuteLoadItemsCommand();

            Assert.IsTrue(moviesViewModel.Movies.Count == 4);
        }

        [TestMethod]
        public async Task TestGetGenreNames()
        {
            Mock<IMoviesService> moviesServiceMock = new Mock<IMoviesService>();
            MoviesResponse moviesResponse = new MoviesResponse()
            {
                TotalPages = 1,
                Page = 1,
                TotalResults = 1,
                Results = new List<MovieResponse>()
                {
                    new MovieResponse()
                    {
                        Id = 1,
                        GenreIds = new List<int>(){1,2},
                        Overview = "This is a movie",
                        PosterPath = "moviepath.jpg",
                        ReleaseDate = "2019-03-24",
                        Title = "My movie"
                    }
                }
            };

            GenresResponse genresResponse = new GenresResponse()
            {
                Genres = new List<GenreResponse>()
                {
                    new GenreResponse()
                    {
                        Id = 1,
                        Name = "Action"
                    },
                    new GenreResponse()
                    {
                        Id = 2,
                        Name = "Comedy"
                    }
                }
            };

            moviesServiceMock.Setup(s => s.GetUpcomingMovies(It.IsAny<int>())).Returns(Task.FromResult(moviesResponse));

            moviesServiceMock.Setup(s => s.GetGenres()).Returns(Task.FromResult(genresResponse));

            MoviesViewModel moviesViewModel = new MoviesViewModel(moviesServiceMock.Object);

            await moviesViewModel.ExecuteLoadItemsCommand();

            Assert.IsTrue(moviesViewModel.Movies.FirstOrDefault().GenreNames == "Action, Comedy");
        }
    }
}
