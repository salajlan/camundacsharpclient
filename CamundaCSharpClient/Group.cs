using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Query;
using RestSharp;

namespace CamundaCSharpClient
{
    public partial class camundaRestClient
    {
        public groupQuery group()
        {
            return new groupQuery(this);
        }
    }
}
