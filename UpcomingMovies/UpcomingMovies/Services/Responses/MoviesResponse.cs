using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UpcomingMovies.Services.Responses
{
    [DataContract]
    public class MoviesResponse
    {
        [DataMember(Name = "results")]
        public List<MovieResponse> Results { get; set; }
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "total_results")]
        public int TotalResults {get;set;}
        [DataMember(Name = "dates")]
        public DatesResponse Dates { get; set; }
        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }

    }
}
