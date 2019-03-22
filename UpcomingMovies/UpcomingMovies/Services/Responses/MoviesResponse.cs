using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Services.Responses
{
    public class MoviesResponse
    {
        public List<MovieResponse> results { get; set; }
        public int Page { get; set; }
        public int TotalResults {get;set;}
        public DatesResponse Dates { get; set; }
        public int TotalPages { get; set; }

    }
}
