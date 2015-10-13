using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class processDefinition : camundaBase
    {
        public string id { get; set; }
        public string key { get; set; }
        public string category { get; set; }
        public object description { get; set; }
        public string name { get; set; }
        public int version { get; set; }
        public string resource { get; set; }
        public string deploymentId { get; set; }
        public string diagram { get; set; }
        public bool suspended { get; set; }
    }
}
