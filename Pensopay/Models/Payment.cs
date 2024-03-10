using Pensopay.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models
{
    public class Payment
    {
        public int id { get; set; }
        public string order_id { get; set; }
        public string type { get; set; }
        public double amount { get; set; }
        public double captured { get; set; }
        public double refunded { get; set; }
        public string currency { get; set; }
        public string state { get; set; }
        public string facilitator { get; set; } = "creditcard";
        public string reference { get; set; }
        public bool testmode { get; set; }
        public bool autocapture { get; set; }
        public  string link { get; set; }
        public string callback_url { get; set; }
        public string success_url { get; set; }
        public string cancel_url { get; set; }
        public Object order { get; set; }
        public ShippingObj shipping { get; set; }
        public Address billing_address { get; set; }
        public Address shipping_address { get; set; }
        public Object variables { get; set; }
        public string expires_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

    }
}
