using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.IntegrationTests.Util
{
    public static class OrderIDGenerator
    {
        public static string GenerateRandomId()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0,20);
        }
    }
}
