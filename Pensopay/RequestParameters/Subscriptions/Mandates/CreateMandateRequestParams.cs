namespace Pensopay.RequestParameters.Subscriptions.Mandates
{
    public class CreateMandateRequestParams
    {
        public required string reference { get; set; }
        public string[] methods { get; set; } = Array.Empty<string>();
        public Uri success_url { get; set; } = new Uri("https://example.com/success");
        public Uri cancel_url { get; set; } = new Uri("https://example.com/cancel");
        public object variables { get; set; } = new();
    }
}
