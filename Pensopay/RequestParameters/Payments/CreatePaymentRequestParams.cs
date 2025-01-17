﻿using Pensopay.Models.Util;

namespace Pensopay.RequestParameters.Payments
{
    public class CreatePaymentRequestParams
    {
        public int amount { get; set; }
        public string currency { get; set; }
        public string order_id { get; set; }
        public Order order { get; set; } = new();
        public bool testmode { get; set; } = false;
        public string success_url { get; set; } = "https://www.success.com/";
        public string cancel_url { get; set; } = "https://www.cancel.com/";
        public string callback_url { get; set; } = "https://www.callback.com/";

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
