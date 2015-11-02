using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using RestSharp;
using Newtonsoft.Json;
using CamundaCSharpClient.Query;
using CamundaCSharpClient.Query.Task;

namespace CamundaCSharpClient
{
    public partial class camundaRestClient
    {        
        public TaskQuery Task()
        {
            return new TaskQuery(this);
        }
    }
}
