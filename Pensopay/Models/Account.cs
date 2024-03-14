using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models
{
    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string vat_number { get; set; }
        public string url { get; set; }
        public string email { get; set; }
        public string private_key { get; set; }
    }
}
