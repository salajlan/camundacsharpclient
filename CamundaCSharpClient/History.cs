using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Query.History;

namespace CamundaCSharpClient
{
    public partial class CamundaRestClient
    {
        public HistoryQuery History()
        {
            return new HistoryQuery(this);
        }
    }
}
