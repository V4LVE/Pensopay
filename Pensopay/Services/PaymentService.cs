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
        public Payments GetPayments(PageParameters? pageParameters = null)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                AddPagingParameters(pageParameters, request);
            };


            return CallEndpoint<Payments>("payments", preRequest);
        }

        /// <summary>
        /// Create a new payment towards the API
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns>The created payment</returns>
        public Payment CreatePayment(CreatePaymentRequestParams requestParams)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                request.AddJsonBody(requestParams);
            };

            return CallEndpoint<Payment>("payments", preRequest);
        }

        /// <summary>
        /// Retrieve a payment from the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns>The requested payment</returns>
        public Payment GetPayment(int paymentId)
        {
            return CallEndpoint<Payment>($"payments/{paymentId}");
        }

        /// <summary>
        /// Call a capture on a payment towards the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="amount"></param>
        /// <returns>The captured payment</returns>
        public Payment CapturePayment(int paymentId, double? amount)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                if (amount != null)
                {
                    request.AddJsonBody(new { amount });
                }
                
            };

            return CallEndpoint<Payment>($"payments/{paymentId}/capture", preRequest);
        }

        /// <summary>
        /// Call a refund on a payment towards the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="amount"></param>
        /// <returns>The refunded payment</returns>
        public Payment RefundPayment(int paymentId, double? amount)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
                if (amount != null)
                {
                    request.AddJsonBody(new { amount });
                }

            };

            return CallEndpoint<Payment>($"payments/{paymentId}/refund", preRequest);
        }

        /// <summary>
        /// Call a cancel on a payment towards the API
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns>The Cancelled payment</returns>
        public Payment CancelPayment(int paymentId)
        {
            Action<RestRequest> preRequest = (request) =>
            {
                request.Method = Method.Post;
            };

            return CallEndpoint<Payment>($"payments/{paymentId}/cancel", preRequest);
        }
    }
}
