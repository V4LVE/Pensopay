using System.ComponentModel.DataAnnotations;

namespace Pensopay.RequestParameters.Subscriptions
{
    public class UpdateSubscriptionRequestParams
    {
        public required int amount { get; set; }
        [Length(3, 3)]
        public required string currency { get; set; }
        [MaxLength(255)]
        public required string description { get; set; }
        public required Uri callback_url { get; set; }
        public object? variables { get; set; } = new();
    }
}
