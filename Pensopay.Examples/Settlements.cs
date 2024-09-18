using Pensopay.Models;
using Pensopay.Parameters;
using Pensopay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Examples
{
    /*
         * Pensopay .NET SDK - Settlement Examples
         * The following examples show how to get and view settlements from the given account.
         */

    public class SettlementsExamples
    {
        // We need to create a new instance of the PensopayClient PaymentService to use the payment methods.
        private static readonly SettlementService _settleMentService = new SettlementService("<<BearerToken>>");

        // Get a list of all settlements
        public void GetAllSettlements()
        {
            var pageParams = new PageParameters() // Paging for sorting
            {
                page = 1,
                per_page = 10
            };

            Settlements settlements = _settleMentService.GetSettlements(pageParams); // Returns a list of settlements inside the object settlements
        }

        // Get a specific settlement
        public void GetSettlement()
        {
            Settlement settlement = _settleMentService.GeSettlement("2f29196a-673b-5ff6-a1a4-6853a5bd9cda"); // Get he settlement with the given ID

            // You can now access the settlement object and get the underlaying information you need
            Console.WriteLine(settlement.id);
        }
    }
}
