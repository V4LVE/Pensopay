using Pensopay.Models.Util;

namespace Pensopay.Models.Subscriptions
{
    public class SubPayment
    {
        public int id { get; set; }
        public string state { get; set; }
        public int captured { get; set; }
        public int refunded { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string link { get; set; }
        public string facilitator { get; set; }
        public string order_id { get; set; }
        public int mandate_id { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public bool testmode { get; set; }
        public bool autocapture { get; set; }
        public string text_on_statement { get; set; }
        public Order order { get; set; }
        public object variables { get; set; }

    }
}
