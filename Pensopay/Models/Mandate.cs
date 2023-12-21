using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Models
{
    public class Mandate
    {
        public int id { get; set; }
        public int subscription_id { get; set; }
        public string mandate_id { get; set; }
        public string state { get; set; }
        public string facilitator { get; set; }
        public string callback_url { get; set; }
        public string link { get; set; }
        public string reference { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
