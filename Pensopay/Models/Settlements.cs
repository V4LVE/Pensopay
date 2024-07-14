using Pensopay.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pensopay.Models
{
    public class Settlements
    {
        public List<Settlement> data { get; set; }
        public PageParameters meta { get; set; }
    }
}
