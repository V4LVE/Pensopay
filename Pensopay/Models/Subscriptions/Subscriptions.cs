using Pensopay.Parameters;

namespace Pensopay.Models.Subscriptions
{
    public class SubscriptionsVm
    {
        public List<Subscription> data { get; set; }
        public PageParameters meta { get; set; }
    }
}
