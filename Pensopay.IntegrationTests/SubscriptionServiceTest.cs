using Pensopay.IntegrationTests.Util;
using Pensopay.Models.Util;
using Pensopay.Parameters;
using Pensopay.RequestParameters.Subscriptions;
using Pensopay.RequestParameters.Subscriptions.Mandates;
using Pensopay.Services.Subscriptions;

namespace Pensopay.IntegrationTests
{
    public class SubscriptionServiceTest
    {
        [Fact]
        public void GetSingleSubscription()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            var sub = service.GetSubscription(1009600);

            //Act

            //Assert
            Assert.True(sub != null);
        }

        [Fact]
        public void GetSubsWithPaging()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            var pageParams = new PageParameters()
            {
                page = 1,
                per_page = 1
            };

            var payments = service.GetAllSubscriptions(pageParams);

            //Act

            //Assert
            Assert.True(payments.data.Count == pageParams.per_page);
        }

        [Fact]
        public void CreateSubscription()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            string randomOrderId = OrderIDGenerator.GenerateRandomId();

            var reqParams = new CreateSubscriptionRequestParams()
            {
                currency = "DKK",
                reference = randomOrderId,
                amount = 10000,
                description = "Test subscription",
                testmode = true
            };

            var task = service.CreateSubscription(reqParams);

            //Act

            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void UpdateSubscription()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);

            var reqParams = new UpdateSubscriptionRequestParams()
            {
                amount = 10000,
                description = "Updated Subscription",
                currency = "DKK",
                callback_url = new Uri("https://www.example.com/callback"),
            };

            var task = service.UpdateSubscription(1000098, reqParams);

            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void CancelSubscription()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            var task = service.CancelSubscription(1000098);
            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void CreateMandate()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            var reqParams = new CreateMandateRequestParams()
            {
                reference = "mandate-1",
            };

            var task = service.MandateService.CreateMandate(reqParams, 1000098);

            Assert.True(task != null);
        }

        [Fact]
        public void GetMandate()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            var task = service.MandateService.GetMandate(1000098, 1009549);
            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void GetMandates()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);

            var pageParams = new PageParameters()
            {
                page = 1,
                per_page = 5
            };

            var task = service.MandateService.GetMandates(1009600, pageParams);
            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void CancelMandate()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            var task = service.MandateService.RevokeMandate(1000098, 1009545);
            //Assert
            Assert.True(task != null);

        }

        [Fact]
        public void CreateSubPayment()
        {
            //Arrange
            SubscriptionService service = new(PensopayConfig.bearerToken);
            string randomOrderId = OrderIDGenerator.GenerateRandomId();

            Address address = new() { name = "test", address = "test", city = "Copenhagen", country = "Denmark", email = "test@test.dk", mobile_number = "12345678", phone_number = "12345678", zipcode = "2300" };

            Order order = new()
            {
                billing_address = address,
                shipping_address = address,
                Basket = new() { new Item() { qty = 1, sku = "123test", name = "Basic Subscription", price = 3900, vat_rate = 25 } }
            };


            var reqParams = new CreatePaymentSubscriptionRequestParams()
            {
                currency = "DKK",
                order_id = randomOrderId,
                amount = 1000,
                text_on_statement = "Test Subscription",
                order = order,
                testmode = true,
                mandate_id = 1009539
            };

            var task = service.CreatePayment(reqParams, 1009600);

            //Act

            //Assert
            Assert.True(task != null);

        }
    }
}
