using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class activityInstance : camundaBase
    {
        public string id { get; set; }
        public object parentActivityInstanceId { get; set; }
        public string activityId { get; set; }
        public string activityType { get; set; }
        public string processInstanceId { get; set; }
        public string processDefinitionId { get; set; }
        public List<activityInstance> childActivityInstances { get; set; }
        public List<object> childTransitionInstances { get; set; }
        public List<string> executionIds { get; set; }
        public string activityName { get; set; }
        public string name { get; set; }
    }
}
