using Pensopay.Parameters;

namespace Pensopay.Models.Subscriptions.Mandates
{
    public class Mandates
    {
        public List<Mandate> data { get; set; }
        public PageParameters meta { get; set; }
    }
}
