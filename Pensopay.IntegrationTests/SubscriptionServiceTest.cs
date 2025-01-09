using Pensopay.IntegrationTests.Util;
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
            var sub = service.GetSubscription(1000098);

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
            var task = service.MandateService.GetMandate(1000098, 1009545);
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
                per_page = 1
            };

            var task = service.MandateService.GetMandates(1000098, pageParams);
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
    }
}
