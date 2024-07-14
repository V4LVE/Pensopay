using Pensopay.IntegrationTests.Util;
using Pensopay.Parameters;
using Pensopay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.IntegrationTests
{
    public class SettlementServiceTest
    {
        [Fact]
        public void GetAllSettlements()
        {
            //Arrange
            SettlementService service = new(PensopayConfig.bearerToken);

            var pageParams = new PageParameters()
            {
                page = 1,
                per_page = 10
            };

            var task = service.GetSettlementsAsync(pageParams);

            //Act
            var result = task.Result;

            //Assert
            Assert.True(result != null);
        }

        [Fact]
        public void GetSettlement()
        {
            //Arrange
            SettlementService service = new(PensopayConfig.bearerToken);
            var task = service.GeSettlementAsync("2f29196a-673b-5ff6-a1a4-6853a5bd9cda");

            //Act
            var result = task.Result;

            //Assert
            Assert.True(result != null);
        }
    }
}
