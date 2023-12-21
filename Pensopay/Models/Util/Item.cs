using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models.Util
{
    public class Item
    {
        public int qty { get; set; }
        public string sku { get; set; }
        public int vat { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }
}
