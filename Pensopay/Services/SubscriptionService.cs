using Pensopay.Models;
using Pensopay.RequestParameters;
using Pensopay.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Services
{
    public class SubscriptionService : PensopayRestClient
    {
        public SubscriptionService(string bearerToken) : base(bearerToken) { }


        #region subscriptions
        /// <summary>
        /// Create a new subscription towards the API
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns>The created subscription</returns>
        public async Task<Subscription> CreateSubscription(CreateSubscriptionRequestParams requestParams)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                request.AddJsonBody(requestParams);
            };

            return CallEndpointAsync<Subscription>("subscriptions", preRequest).Result;
        }

        /// <summary>
        /// Cancel a subscription towards the API
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns>The cancelled subscription</returns>
        public async Task<Subscription> CancelSubscription(int subscriptionId)
        {
            return await CallEndpointAsync<Subscription>($"subscriptions/{subscriptionId}/cancel", (request) => request.Method = Method.Post);
        }

        /// <summary>
        /// Create a new recurring payment for a subscription towards the API
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns>The created recurring payment</returns>
        public async Task<Payment> CreateRecurringPayment(CreateRecurringRequestParams requestParams)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                request.AddJsonBody(requestParams);
            };

            return CallEndpointAsync<Payment>($"subscriptions/{requestParams.subscription}/payment", preRequest).Result;
        }

        /// <summary>
        /// Retrieve a specifik subscription from the API
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns>The requested subscription</returns>
        public async Task<Subscription> GetSubscription(int subscriptionId)
        {
            return await CallEndpointAsync<Subscription>($"subscriptions/{subscriptionId}");
        }

        /// <summary>
        /// Retrieve all subscriptions from the API
        /// </summary>
        /// <returns>a list of subscriptions</returns>
        public async Task<List<Subscription>> GetAllSubscriptions()
        {
            return await CallEndpointAsync<List<Subscription>>("subscriptions");
        }
        #endregion

        #region Mandates

        #endregion
    }
}
