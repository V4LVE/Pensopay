using System.ComponentModel.DataAnnotations;

namespace Pensopay.RequestParameters.Subscriptions
{
    public class CreateSubscriptionRequestParams
    {
        [MaxLength(30)]
        public required string reference { get; set; }
        public required int amount { get; set; }
        [StringLength(3)]
        public required string currency { get; set; }
        [MaxLength(255)]
        public required string description { get; set; }

        public Uri? callback_url { get; set; } = new Uri("https://example.com/callback");
        public Uri? success_url { get; set; } = new Uri("https://example.com/success");
        public Uri? cancel_url { get; set; } = new Uri("https://example.com/cancel");
        public bool? testmode { get; set; }
        public string[]? methods { get; set; } = Array.Empty<string>();
        public object? variables { get; set; } = new();

    }
}
