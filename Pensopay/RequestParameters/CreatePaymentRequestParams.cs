using Pensopay.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Pensopay.RequestParameters
{
    public class CreatePaymentRequestParams
    {
        public int amount { get; set; }
        public string currency { get; set; }    
        public string order_id { get; set; }
        public Order order { get; set; } = new();

        public CreatePaymentRequestParams()
        {
      
        }

        public CreatePaymentRequestParams(string currency, string order_id, int amount)
        {
            this.currency = currency;
            this.order_id = order_id;
            this.amount = amount;
        }
    }
}
