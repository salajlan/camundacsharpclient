using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using RestSharp;
using Newtonsoft.Json;
using CamundaCSharpClient.Query.ProcessInstance;

namespace CamundaCSharpClient
{
    public partial class CamundaRestClient
    {
        public ProcessInstanceQuery ProcessInstance()
        {
            return new ProcessInstanceQuery(this);
        }
    }
}
