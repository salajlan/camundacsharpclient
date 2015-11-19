using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Query.History
{
    public class HistoryQuery : QueryBase
    {
        public HistoryQuery(CamundaRestClient client) : base(client)
        { 
        }

        public DetailsQuery Details()
        {
            return new DetailsQuery(client);
        }

        public HistoryProcessInstanceQuery ProcessInstance()
        {
            return new HistoryProcessInstanceQuery(client);
        }

        public HistoryTaskQuery Task()
        {
            return new HistoryTaskQuery(client);
        }
    }
}
