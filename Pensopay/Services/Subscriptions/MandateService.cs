using Pensopay.Models.Subscriptions.Mandates;
using Pensopay.Parameters;
using Pensopay.RequestParameters.Subscriptions.Mandates;
using Pensopay.Util;
using RestSharp;

namespace Pensopay.Services.Subscriptions
{
    public class MandateService : PensopayRestClient
    {
        public MandateService(string bearerToken) : base(bearerToken)
        {
        }

        /// <summary>
        /// Retrieve a mandate from the API for a specific subscription
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="mandateId"></param>
        /// <returns>The requested mandate</returns>
        public Mandate GetMandate(int subscriptionId, int mandateId)
        {
            return CallEndpoint<Mandate>($"subscriptions/{subscriptionId}/mandates/{mandateId}");
        }

        /// <summary>
        /// Retrieve all mandates from the API for a specific subscription
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <param name="subscriptionId"></param>
        /// <returns>A list of mandates</returns>
        public Mandates GetMandates(int subscriptionId, PageParameters? pageParameters = null)
        {

            Action<RestRequest> preRequest = (request) =>
            {
                AddPagingParameters(pageParameters, request);
            };


            return CallEndpoint<Mandates>($"subscriptions/{subscriptionId}/mandates", preRequest);
        }

        /// <summary>
        /// Revoke a mandate from the API for a specific subscription
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="mandateId"></param>
        /// <returns>The revoked mandate</returns>
        public Mandate RevokeMandate(int subscriptionId, int mandateId)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
            };
            return CallEndpoint<Mandate>($"subscriptions/{subscriptionId}/mandates/{mandateId}/revoke", preRequest);
        }

        /// <summary>
        /// Create a new mandate towards the API for a specific subscription
        /// </summary>
        /// <param name="requestParams"></param>
        /// <param name="subscriptionId"></param>
        /// <returns>the newly created mandate</returns>
        public Mandates CreateMandate(CreateMandateRequestParams requestParams, int subscriptionId)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                request.AddJsonBody(requestParams);
            };

            return CallEndpoint<Mandates>($"subscriptions/{subscriptionId}/mandates", preRequest);
        }
    }
}
