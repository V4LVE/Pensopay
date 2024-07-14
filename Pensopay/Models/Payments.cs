using Pensopay.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models
{
    public class Payments
    {
        public List<Payment> data { get; set; }
        public PageParameters meta { get; set; }
    }
}
