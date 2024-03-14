using Pensopay.Models;
using Pensopay.Parameters;
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
    public class PaymentService : PensopayRestClient
    {
        public PaymentService(string bearerToken) : base(bearerToken) { }

        /// <summary>
        /// Retrieve all payments from the API
        /// </summary>
        /// <returns>a list of payments</returns>
        public async Task<Payments> GetPaymentsAsync(PageParameters? pageParameters = null)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                AddPagingParameters(pageParameters, request);
            };


            return CallEndpointAsync<Payments>("payments", preRequest).Result;
        }

        /// <summary>
        /// Create a new payment towards the API
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns>The created payment</returns>
        public async Task<Payment> CreatePaymentAsync(CreatePaymentRequestParams requestParams)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                request.AddJsonBody(requestParams);
            };

            return CallEndpointAsync<Payment>("payments", preRequest).Result;
        }

        /// <summary>
        /// Retrieve a payment from the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns>The requested payment</returns>
        public async Task<Payment> GetPaymentAsync(int paymentId)
        {
            return CallEndpointAsync<Payment>($"payments/{paymentId}").Result;
        }

        /// <summary>
        /// Call a capture on a payment towards the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="amount"></param>
        /// <returns>The captured payment</returns>
        public async Task<Payment> CapturePaymentAsync(int paymentId, double? amount)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                if (amount != null)
                {
                    request.AddJsonBody(new { amount });
                }
                
            };

            return CallEndpointAsync<Payment>($"payments/{paymentId}/capture", preRequest).Result;
        }

        /// <summary>
        /// Call a refund on a payment towards the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="amount"></param>
        /// <returns>The refunded payment</returns>
        public async Task<Payment> RefundPaymentAsync(int paymentId, double? amount)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                if (amount != null)
                {
                    request.AddJsonBody(new { amount });
                }

            };

            return CallEndpointAsync<Payment>($"payments/{paymentId}/refund", preRequest).Result;
        }

        /// <summary>
        /// Call a cancel on a payment towards the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns>The Cancelled payment</returns>
        public async Task<Payment> CancelPaymentAsync(int paymentId)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
            };

            return CallEndpointAsync<Payment>($"payments/{paymentId}/cancel", preRequest).Result;
        }
    }
}
