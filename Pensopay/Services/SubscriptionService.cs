using Pensopay.Models.Subscriptions;
using Pensopay.Util;

namespace Pensopay.Services
{
    public class SubscriptionService : PensopayRestClient
    {
        public SubscriptionService(string bearerToken) : base(bearerToken) { }

        /// <summary>
        /// Retrieve a subscription from the API
        /// </summary>
        /// <param name="subId"></param>
        /// <returns>The requested payment</returns>
        public Subscription GetSubscription(int subId)
        {
            return CallEndpoint<Subscription>($"subscriptions/{subId}");
        }
    }
}
