
using Pensopay.IntegrationTests.Properties;
using Pensopay.IntegrationTests.Util;
using Pensopay.Parameters;
using Pensopay.RequestParameters;
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
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var payment =  service.GetPaymentAsync(7223370);

            //Act
            var result = payment.Result;

            //Assert
            Assert.True(result != null);
        }

        [Fact]
        public void GetPayments()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var payments = service.GetPaymentsAsync();

            //Act
            var result = payments.Result;

            //Assert
            Assert.True(result.Data != null);
        }

        [Fact]
        public void GetPaymentsWithPaging()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var pageParams = new PageParameters()
            {
                current_page = 1,
                per_page = 10
            };

            var payments = service.GetPaymentsAsync(pageParams);

            //Act
            var result = payments.Result;

            //Assert
            Assert.True(result.Data.Count == pageParams.per_page);
        }

        [Fact]
        public void CreatePayment()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            string randomOrderid = OrderIDGenerator.GenerateRandomId();

            var reqParams = new CreatePaymentRequestParams("DKK", randomOrderid, 1000);
            var task = service.CreatePaymentAsync(reqParams);

            //Act
            var result = task.Result;

            //Assert
            Assert.True(result != null);
        }
    }
}