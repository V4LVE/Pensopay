using Pensopay.IntegrationTests.Util;
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
    }
}
