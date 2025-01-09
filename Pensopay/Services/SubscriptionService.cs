using Pensopay.Models.Subscriptions;
using Pensopay.Parameters;
using Pensopay.RequestParameters.Subscriptions;
using Pensopay.Util;
using RestSharp;

namespace Pensopay.Services
{
    public class SubscriptionService : PensopayRestClient
    {
        public SubscriptionService(string bearerToken) : base(bearerToken) { }

        /// <summary>
        /// Retrieve a subscription from the API
        /// </summary>
        /// <param name="subId"></param>
        /// <returns>The requested subscription</returns>
        public Subscription GetSubscription(int subId)
        {
            return CallEndpoint<Subscription>($"subscriptions/{subId}");
        }

        /// <summary>
        /// Retrieve all subscriptions from the API
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns>A list of all subscriptions with paging</returns>
        public Subscriptions GetAllSubscriptions(PageParameters? pageParameters = null)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                AddPagingParameters(pageParameters, request);
            };


            return CallEndpoint<Subscriptions>("subscriptions", preRequest);
        }

        /// <summary>
        /// Create a new subscription towards the API
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns>the newly created subscription</returns>
        public Subscription CreateSubscription(CreateSubscriptionRequestParams requestParams)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                request.AddJsonBody(requestParams);
            };

            return CallEndpoint<Subscription>("subscriptions", preRequest);
        }

        /// <summary>
        /// Update a subscription towards the API
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="updateParams"></param>
        /// <returns>the newly updated subscription</returns>
        public Subscription UpdateSubscription(int subscriptionId, UpdateSubscriptionRequestParams updateParams)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Patch;
                request.AddJsonBody(updateParams);
            };
            return CallEndpoint<Subscription>($"subscriptions/{subscriptionId}", preRequest);
        }

        /// <summary>
        /// Cancel a subscription towards the API
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns>The cancelled subscription</returns>
        public Subscription CancelSubscription(int subscriptionId)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
            };
            return CallEndpoint<Subscription>($"subscriptions/{subscriptionId}/cancel", preRequest);
        }
    }
}
