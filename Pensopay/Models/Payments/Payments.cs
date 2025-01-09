using Pensopay.Parameters;

namespace Pensopay.Models.Payments
{
    public class Payments
    {
        public List<Payment> data { get; set; }
        public PageParameters meta { get; set; }
    }
}
