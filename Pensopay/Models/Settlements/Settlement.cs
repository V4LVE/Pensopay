using Pensopay.Models.Util.Settlements;

namespace Pensopay.Models.Settlements
{
    public class Settlement
    {
        public string currency { get; set; }
        public Fees fees { get; set; }
        public string id { get; set; }
        public Payout payout { get; set; }
        public Period period { get; set; }
        public bool settled { get; set; }
        public Summary summary { get; set; }
    }
}
