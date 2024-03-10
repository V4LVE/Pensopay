using Pensopay.IntegrationTests.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.IntegrationTests.Util
{
    internal static class PensopayConfig
    {
        public static string bearerToken
        {
            get
            {
                string token = Resources.PENSOPAY_BTOKEN;
                if (String.IsNullOrWhiteSpace(token))
                {
                    throw new Exception("Please set the bearer token");
                }
                return token;
            }
        }
    }
}
