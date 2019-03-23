using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpcomingMovies.ApiAccess
{
    public class AuthenticatedHttpClientHandler : NativeMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (await ValidateResponse(response))
                return response;
            else
                return null;
        }

        private async Task<bool> ValidateResponse(HttpResponseMessage response)
        {
            if (response == null)
                return false;

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception("Oops! There was an error in your request.");
            }

            return true;
        }
    }
}
