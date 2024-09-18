using Pensopay.IntegrationTests.Util;
using Pensopay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.IntegrationTests
{
    public class AccountServiceTest
    {
        [Fact]
        public void GetAccount()
        {
            //Arrange
            AccountService service = new(PensopayConfig.bearerToken);
            var task = service.GetAccount();

            //Act

            //Assert
            Assert.True(task != null);
        }

        [Fact]
        public void GetMethods()
        {
            //Arrange
            AccountService service = new(PensopayConfig.bearerToken);
            var task = service.GetMethods();
            //Act
            //Assert
            Assert.True(task != null);
        }
    }
}
