
using Pensopay.IntegrationTests.Properties;
using Pensopay.IntegrationTests.Util;
using Pensopay.Services;
using RestSharp;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Pensopay.IntegrationTests
{
    public class PaymentServiceTest
    {
        [Fact]
        public void GetSinglePayment()
        {
            PaymentService service = new(PensopayConfig.bearerToken);
            var payment =  service.GetPaymentAsync(7223370);
            var result = payment.Result;

            Assert.True(result != null);
        }

        [Fact]
        public void GetPayments()
        {
            PaymentService service = new(PensopayConfig.bearerToken);
            var payments = service.GetPaymentsAsync();
            var result = payments.Result;

            Assert.True(result != null);
        }

        [Fact]
        public void CreatePayment()
        {
            RestClientOptions clientOptions = new("https://api.pensopay.com/v1/")
            {
                UserAgent = "Pensopay .NET SDK",
                FollowRedirects = true
            };
             string _bearerToken = PensopayConfig.bearerToken;
            RestClient client = new RestClient(options: clientOptions);

            RestRequest request = CreateRequest(endpointName);

            preRequest?.Invoke(request);

            RestResponse<T> response = await Client.ExecuteAsync<T>(request);
        }
    }
}