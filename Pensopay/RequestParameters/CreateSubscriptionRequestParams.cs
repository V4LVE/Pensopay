using Pensopay.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.RequestParameters
{
    public class CreateSubscriptionRequestParams
    {
        public CreateSubscriptionRequestParams(string currency, string subscription_id, string description, double amount)
        {
            this.amount = amount;
            this.currency = currency;
            this.description = description;
            this.subscription_id = subscription_id;
        }

        public string subscription_id { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public Order order { get; set; }
        public ShippingObj shipping { get; set; }
        public Address billing_address { get; set; }
        public Address shipping_address { get; set; }
        public Variables variables { get; set; }
    }
}
