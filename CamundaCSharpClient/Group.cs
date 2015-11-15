using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Query;
using RestSharp;

namespace CamundaCSharpClient
{
    public partial class CamundaRestClient
    {
        public GroupQuery Group()
        {
            return new GroupQuery(this);
        }
    }
}
