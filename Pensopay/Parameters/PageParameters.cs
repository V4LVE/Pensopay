using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Parameters
{
    public struct PageParameters
    {
        public PageParameters(int currentPage, int perPage, int total)
        {
            page = currentPage;
            per_page = perPage;
            this.total = total;
        }

        public int page { get; set; }


        public int per_page { get; set; }

        public int total { get; set; }

    }
}
