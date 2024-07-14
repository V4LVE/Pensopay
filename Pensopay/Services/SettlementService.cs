using Pensopay.Models;
using Pensopay.Parameters;
using Pensopay.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Services
{
    public class SettlementService : PensopayRestClient
    {
        public SettlementService(string bearerToken) : base(bearerToken) { }

        /// <summary>
        /// Get all settlements from the API
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        public async Task<Settlements> GetSettlementsAsync(PageParameters? pageParameters = null)
        {

            Action<RestRequest> preRequest = (request) =>
            {
                AddPagingParameters(pageParameters, request);
            };


            return CallEndpointAsync<Settlements>("settlements", preRequest).Result;
        }

        /// <summary>
        /// Get a specific settlement from the API
        /// </summary>
        /// <param name="settlementId"></param>
        /// <returns></returns>
        public async Task<Settlement> GeSettlementAsync(string settlementId)
        {
            return CallEndpointAsync<Settlement>($"settlements/{settlementId}").Result;
        }
    }
}
