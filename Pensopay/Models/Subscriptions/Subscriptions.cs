using Pensopay.Parameters;

namespace Pensopay.Models.Subscriptions
{
    public class Subscriptions
    {
        public List<Subscription> data { get; set; }
        public PageParameters meta { get; set; }
    }
}
