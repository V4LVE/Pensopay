using Pensopay.Models;
using Pensopay.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.RequestParameters
{
    public class CreateRecurringRequestParams
    {

        public CreateRecurringRequestParams(int subscriptionId, string order_id, string currency, double? amount)
        {
            this.subscription = subscriptionId;
            this.order_id = order_id;
            this.currency = currency;

            if (amount.HasValue)
            {
                this.amount = amount.Value;
            }

        }

        public int subscription { get; set; }
        public string order_id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
        public Order order { get; set; }
        public Variables variables { get; set; }
    }
}
