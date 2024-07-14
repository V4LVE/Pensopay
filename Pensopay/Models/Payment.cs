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
        public string acquirer { get; set; }
        public int amount { get; set; }
        public bool autocapture { get; set; }
        public string callback_url { get; set; }
        public string cancel_url { get; set; }
        public int captured { get; set; }
        public DateTime created_at { get; set; }
        public string currency { get; set; }
        public string facilitator { get; set; }
        public int id { get; set; }
        public string link { get; set; }
        public string link_uuid { get; set; }
        public List<string> methods { get; set; }
        public Order order { get; set; }
        public string order_id { get; set; }
        public string reference { get; set; }
        public int refunded { get; set; }
        public string state { get; set; }
        public string success_url { get; set; }
        public bool testmode { get; set; }
        public DateTime updated_at { get; set; }
        public Variables variables { get; set; }

    }
}
