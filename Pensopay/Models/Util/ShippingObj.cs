using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models.Util
{
    public class ShippingObj
    {
        public double amount { get; set; }
        public string method { get; set; }
        public string company { get; set; }
        public double vat_rate { get; set; }
    }
}
