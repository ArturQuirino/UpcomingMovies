using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UpcomingMovies.Utils;

namespace UpcomingMovies.ApiAccess
{
    public class MoviesApiAcess
    {
        private static HttpClient _client;
        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                    _client = new HttpClient(new AuthenticatedHttpClientHandler())
                    {
                        BaseAddress = new Uri(Constants.URL_BASE)
                    };
                return _client;
            }
        }
        

        public static Api GetClientApi<Api>()
        {
            return RestService.For<Api>(Client);
        }
    }
}
