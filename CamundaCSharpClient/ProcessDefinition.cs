using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using RestSharp;
using Newtonsoft.Json;
using CamundaCSharpClient.Query;
using CamundaCSharpClient.Model.processDefinition;

namespace CamundaCSharpClient
{
    public partial class camundaRestClient
    {
        public ProcessDefinitionQuery ProcessDefinition()
        {
            return new ProcessDefinitionQuery(this);
        }
    }
}
