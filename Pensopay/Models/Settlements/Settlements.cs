using Pensopay.Parameters;

namespace Pensopay.Models.Settlements
{
    public class Settlements
    {
        public List<Settlement> data { get; set; }
        public PageParameters meta { get; set; }
    }
}
