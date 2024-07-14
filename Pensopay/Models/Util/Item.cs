using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models.Util
{
    public class Item
    {
        public string name { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
        public string sku { get; set; }
        public double vat_rate { get; set; }
    }
}
