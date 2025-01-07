using Pensopay.Models.Subscriptions;
using Pensopay.Parameters;
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
    }
}
