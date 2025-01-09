using Pensopay.Models.Util;
using System.ComponentModel.DataAnnotations;

namespace Pensopay.RequestParameters.Subscriptions
{
    public class CreatePaymentSubscriptionRequestParams
    {
        [MaxLength(30)]
        public required string order_id { get; set; }
        public int? mandate_id { get; set; } = 0;
        public int? amount { get; set; }
        public string? currency { get; set; }
        public bool? testmode { get; set; } = false;
        public bool? autocapture { get; set; } = false;
        [Length(2, 22)]
        public required string text_on_statement { get; set; }
        public required Order order { get; set; }
        public object? variables { get; set; } = new();
    }
}
