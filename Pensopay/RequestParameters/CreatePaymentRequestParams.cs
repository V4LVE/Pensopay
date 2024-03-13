using Pensopay.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.RequestParameters
{
    public class CreatePaymentRequestParams
    {
        public string order_id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
        public string facilitator { get; set; } = "creditcard";
        public Order? order { get; set; } = new();
        public ShippingObj shipping { get; set; }
        public Address billing_address { get; set; }
        public Address shipping_address { get; set; }
        public Variables variables { get; set; }

        public CreatePaymentRequestParams()
        {
            
        }

        public CreatePaymentRequestParams(string currency, string order_id, double amount)
        {
            this.currency = currency;
            this.order_id = order_id;
            this.amount = amount;
        }
    }
}
