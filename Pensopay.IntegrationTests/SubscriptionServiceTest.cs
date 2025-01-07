using Pensopay.IntegrationTests.Util;
using Pensopay.Parameters;
using Pensopay.Services;

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
    }
}
