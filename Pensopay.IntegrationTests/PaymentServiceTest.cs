
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
            var payment =  service.GetPayment(14572581);

            //Act

            //Assert
            Assert.True(payment != null);
        }

        [Fact]
        public void GetPayments()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var payments = service.GetPayments();

            //Act

            //Assert
            Assert.True(payments != null);
        }

        [Fact]
        public void GetPaymentsWithPaging()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var pageParams = new PageParameters()
            {
                page = 1,
                per_page = 10
            };

            var payments = service.GetPayments(pageParams);

            //Act

            //Assert
            Assert.True(payments.data.Count == pageParams.per_page);
        }

        [Fact]
        public void CreatePayment()
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
                amount = 1000,
                order = order,
                testmode = true
            };

            var task = service.CreatePayment(reqParams);

            //Act

            //Assert
            Assert.True(task != null);

        }

        [Fact]
        public void CapturePayment()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);

            var task = service.CapturePayment(14573073, 1000);

            //Act

            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void CancelPayent()
        {
            //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var task = service.CancelPayment(14573145);
            //Act
            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void RefundPayent()
        {
             //Arrange
            PaymentService service = new(PensopayConfig.bearerToken);
            var task = service.RefundPayment(14573073, 1000);

            //Act

            //Assert
            Assert.True(task != null);
        }
    }
}