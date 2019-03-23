using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public List<int> GenreIds { get; set; }
        public string GenreNames { get; set; }
        public string ReleaseDate { get; set; }
        public string Overview { get; set; }
    }
}
