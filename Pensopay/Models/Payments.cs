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
        public List<Payment> Data { get; set; }
        public PageParameters Meta { get; set; }
    }
}
