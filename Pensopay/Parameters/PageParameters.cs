using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.Parameters
{
    public struct PageParameters
    {
        public PageParameters(int currentPage, int lastPage, int perPage, int total)
        {
            current_page = currentPage;
            last_page = lastPage;
            per_page = perPage;
            this.total = total;
        }

        public int current_page { get; set; }

        public int last_page { get; set; }

        public int per_page { get; set; }

        public int total { get; set; }
    }
}
