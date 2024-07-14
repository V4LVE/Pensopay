using Pensopay.Models.Util.Settlements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models
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
