namespace Pensopay.Models.Subscriptions
{
    public class Subscription
    {
        public int id { get; set; }
        public string state { get; set; }
        public string link { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string reference { get; set; }

        public int? amount { get; set; }
        public string? currency { get; set; }
        public string? description { get; set; }
        public Uri? callback_url { get; set; }
        public Uri? success_url { get; set; }
        public Uri? cancel_url { get; set; }
        public string[]? methods { get; set; }
        public object? variables { get; set; }
    }
}
