using CamundaCSharpClient.Query.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient
{
    public partial class camundaRestClient
    {
        public HistoryQuery History()
        {
            return new HistoryQuery(this);
        }
    }
}
