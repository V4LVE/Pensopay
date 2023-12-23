using Pensopay.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Util
{
    public abstract class PensopayRestClient
    {
        private const string _apiUrl = "https://api.pensopay.com/v1/";

        protected RestClient Client { get; set; }

        protected PensopayRestClient(string bearerToken)
        {
            if (string.IsNullOrEmpty(bearerToken))
                throw new ArgumentNullException(nameof(bearerToken));

            RestClientOptions clientOptions = new(_apiUrl)
            {
                UserAgent = "Pensopay .NET SDK",
                FollowRedirects = true,
            };

            Client = new RestClient(options: clientOptions);
        }

        protected RestRequest CreateRequest(string resource)
        {
            RestRequest request = new(resource);
            request.AddHeader("accept", "application/json");
            return request;
        }

        protected async Task<T> CallEndpointAsync<T>(string endpointName, Action<RestRequest> preRequest = null) where T : new()
        {
            RestRequest request = CreateRequest(endpointName);

            preRequest?.Invoke(request);

            RestResponse<T> response = await Client.ExecuteAsync<T>(request);

            // Handle errors and throw exceptions if needed 
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new DirectoryNotFoundException("The Called endpoint was not found");
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("You are not authorized to access this endpoint");
            }
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }


            return response.Data;
        }

    }
}
