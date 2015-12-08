using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class ActivityInstanceModel : CamundaBase
    {
        public string Id { get; set; }

        public object ParentActivityInstanceId { get; set; }

        public string ActivityId { get; set; }

        public string ActivityType { get; set; }

        public string ProcessInstanceId { get; set; }

        public string ProcessDefinitionId { get; set; }

        public List<ActivityInstanceModel> ChildActivityInstances { get; set; }

        public List<object> ChildTransitionInstances { get; set; }

        public List<string> ExecutionIds { get; set; }

        public string ActivityName { get; set; }

        public string Name { get; set; }
    }
}
