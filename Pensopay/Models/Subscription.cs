using Pensopay.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models
{
    public class Subscription
    {
        public int id { get; set; }
        public string subscription_id { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string state { get; set; }
        public string description { get; set; }
        public string callback_url { get; set; }
        public Variables variables { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
