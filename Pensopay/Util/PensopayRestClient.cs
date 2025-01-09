using Pensopay.Parameters;
using RestSharp;

namespace Pensopay.Util
{
    public abstract class PensopayRestClient
    {
        private const string _apiUrl = "https://api.pensopay.com/v2/";
        private readonly string _bearerToken;

        protected RestClient Client { get; set; }

        protected PensopayRestClient(string bearerToken)
        {
            if (string.IsNullOrEmpty(bearerToken))
                throw new ArgumentNullException(nameof(bearerToken));

            RestClientOptions clientOptions = new(_apiUrl)
            {
                UserAgent = "Pensopay .NET SDK",
                FollowRedirects = true
            };
            _bearerToken = bearerToken;
            Client = new RestClient(options: clientOptions);
        }

        protected RestRequest CreateRequest(string resource)
        {
            RestRequest request = new(resource);
            request.AddHeader("accept", "application/json");
            request.AddHeader("accept-version", "v10");
            request.AddHeader("authorization", $"Bearer {_bearerToken}");
            return request;
        }

        protected void AddPagingParameters(Nullable<PageParameters> pageParameters, RestRequest request)
        {
            if (pageParameters == null)
                return;
            request.AddParameter("page", pageParameters.Value.page);
            request.AddParameter("per_page", pageParameters.Value.per_page);
            request.AddParameter("total", pageParameters.Value.total);
        }

        protected void AddSortingParameters(Nullable<SortingParameters> sortingParameters, RestRequest request)
        {
            if (sortingParameters == null)
                return;

            if (sortingParameters.Value.SortBy == String.Empty)
                throw new ArgumentException("sort_by cannot be empty");

            request.AddParameter("sort_by", sortingParameters.Value.SortBy);
            request.AddParameter("sort_dir", sortingParameters.Value.SortDirection.ToString());
        }

        protected T CallEndpoint<T>(string endpointName, Action<RestRequest> preRequest = null) where T : new()
        {
            RestRequest request = CreateRequest(endpointName);

            preRequest?.Invoke(request);

            RestResponse<T> response = Client.Execute<T>(request);

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
                throw new Exception(response.Content, response.ErrorException)!;
            }


            return response.Data;
        }

    }
}
