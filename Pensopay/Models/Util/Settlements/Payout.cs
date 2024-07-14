using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models.Util.Settlements
{
    public class Payout
    {
        public int amount { get; set; }
        public string cancelled_date { get; set; }
        public string date { get; set; }
        public string descriptor { get; set; }
    }
}
