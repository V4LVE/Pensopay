namespace Pensopay.Models.Subscriptions.Mandates
{
    public class Mandate
    {
        public int id { get; set; }
        public int subscription_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string state { get; set; }
        public string link { get; set; }
        public string reference { get; set; }
        public string[]? methods { get; set; }
        public Uri success_url { get; set; }
        public Uri cancel_url { get; set; }
        public object variables { get; set; }
    }
}
