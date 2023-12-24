using Pensopay.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensopay.RequestParameters
{
    public class CreateMandateRequestParams
    {
        public CreateMandateRequestParams(int subscriptionId, string mandate_id)
        {
            this.mandate_id = mandate_id;
            this.subscription = subscriptionId;
        }

        public int subscription { get; set; }
        public string mandate_id { get; set; }
        public string facilitator { get; set; } = "creditcard";
        public Variables variables { get; set; }
    }
}
