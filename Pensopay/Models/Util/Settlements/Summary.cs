using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models.Util.Settlements
{
    public class Summary
    {
        public int chargebacks { get; set; }
        public int credits { get; set; }
        public int fees { get; set; }
        public int net { get; set; }
        public int other_postings { get; set; }
        public int refunds { get; set; }
        public int sales { get; set; }
    }
}
