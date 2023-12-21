using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay
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

    }
}
