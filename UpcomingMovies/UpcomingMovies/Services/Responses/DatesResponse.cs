using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UpcomingMovies.Services.Responses
{
    [DataContract]
    public class DatesResponse
    {
        [DataMember(Name = "maximum")]
        public DateTime Maximum { get; set; }

        [DataMember(Name = "minimum")]
        public DateTime Minimum { get; set; }
    }
}
