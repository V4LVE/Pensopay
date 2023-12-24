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
        /// <summary>
        /// Create a new mandate for a subscription towards the API
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns>The created mandate</returns>
        public async Task<Mandate> CreateMandate(CreateMandateRequestParams requestParams)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                request.AddJsonBody(requestParams);
            };

            return CallEndpointAsync<Mandate>($"subscriptions/{requestParams.subscription}/mandates", preRequest).Result;
        }

        public async Task<Mandate> RevokeMandate(int subscriptionId, int mandateId)
        {
            return await CallEndpointAsync<Mandate>($"subscriptions/{subscriptionId}/mandates/{mandateId}/revoke", (request) => request.Method = Method.Post);
        }

        /// <summary>
        /// Retrieve a specific mandate from the API
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="mandateid"></param>
        /// <returns>the requested mandate</returns>
        public async Task<Mandate> GetMandate(int subscriptionId, int mandateid)
        {
            return await CallEndpointAsync<Mandate>($"subscriptions/{subscriptionId}/mandates/{mandateid}");
        }

        /// <summary>
        /// retrieve all mandates for a subscriptions from the API
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns>A list of mandates</returns>
        public async Task<List<Mandate>> GetAllMandates(int subscriptionId)
        {
            return await CallEndpointAsync<List<Mandate>>($"subscriptions/{subscriptionId}/mandates");
        }
        #endregion
    }
}
