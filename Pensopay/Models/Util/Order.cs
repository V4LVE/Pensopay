using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models.Util
{
    public class Order
    {
        public Address billing_address { get; set; }
        public Address shipping_address { get; set; }

        public List<Item> Basket { get; set; }
    }
}
