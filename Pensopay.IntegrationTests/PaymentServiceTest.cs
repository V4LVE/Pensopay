
using Pensopay.IntegrationTests.Properties;
using Pensopay.IntegrationTests.Util;
using Pensopay.Models.Util;
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
            var payment =  service.GetPaymentAsync(11694090);

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

        [Fact]
        public void CreatePaymentWithBasket()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            string randomOrderId = OrderIDGenerator.GenerateRandomId();

            Address address = new() { name = "test", address = "test", city = "Copenhagen", country = "Denmark", email = "test@test.dk", mobile_number = "12345678", phone_number = "12345678", zipcode = "2300" };

            Order order = new()
            {
                billing_address = address,
                shipping_address = address,
                Basket = new() { new Item() {qty = 2, sku = "123test", name = "The Elder Wand", price = 10000, vat_rate = 25 } }
            };


            var reqParams = new CreatePaymentRequestParams()
            {
                currency = "DKK",
                order_id = randomOrderId,
                amount = 100,
                order = order
            };

            var task = service.CreatePaymentAsync(reqParams);

            //Act
            var result = task.Result;

            //Assert
            Assert.True(result != null);

        }

        [Fact]
        public void CapturePayment()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);

            var task = service.CapturePaymentAsync(11694090, 100);

            //Act
            var result = task.Result;

            //Assert
            Assert.True(result != null);
        }

        [Fact]
        public void CancelPayent()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var task = service.CancelPaymentAsync(11694090);
            //Act
            var result = task.Result;
            //Assert
            Assert.True(result != null);
        }

        [Fact]
        public void RefundPayent()
        {
             //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var task = service.RefundPaymentAsync(11694090, 100);

            //Act
            var result = task.Result;

            //Assert
            Assert.True(result != null);
        }
    }
}