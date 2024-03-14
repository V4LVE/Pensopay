using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models.Util
{
    public class Item
    {
        public int qty { get; set; } = 0;
        public string sku { get; set; } = "";
        public int vat_rate { get; set; } = 0;
        public string name { get; set; } = "";
        public double price { get; set; } = 0;
    }
}
