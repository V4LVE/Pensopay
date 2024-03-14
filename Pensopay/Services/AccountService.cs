using Pensopay.Models;
using Pensopay.Models.Util;
using Pensopay.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Pensopay.Services
{
    public class AccountService : PensopayRestClient
    {
        public AccountService(string bearerToken) : base(bearerToken) { }


        /// <summary>
        /// Get the account details from the API
        /// </summary>
        /// <returns>The requested account</returns>
        public async Task<Account> GetAccountAsync()
        {
            return CallEndpointAsync<Account>("account").Result;
        }


        /// <summary>
        /// Get the available methods from the API
        /// </summary>
        /// <returns>A list of strings for the given available methods</returns>
        public async Task<Methods> GetMethodsAsync()
        {
            return CallEndpointAsync<Methods>("methods").Result;
        }
    }
}
