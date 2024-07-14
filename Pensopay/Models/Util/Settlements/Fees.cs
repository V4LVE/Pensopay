using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Pensopay.Models.Util.Settlements
{
    public class Fees
    {
        [JsonPropertyName("3dsecure")]
        public int _3dsecure { get; set; }
        public int authorisations { get; set; }
        public int chargebacks { get; set; }
        public int credits { get; set; }
        public int interchange { get; set; }
        public int late_capture { get; set; }
        public int minimum_processing { get; set; }
        public int refunds { get; set; }
        public int retrieval_requests { get; set; }
        public int sales { get; set; }
        public int scheme { get; set; }
        public int series { get; set; }
        public int service { get; set; }
        public int wire_transfer { get; set; }
    }
}
