using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.processDefinition
{
    public class processDefinitionSuspend : camundaBase
    {
        public bool suspended { get; set; }
        public bool includeProcessInstances { get; set; }
        public DateTime executionDate { get; set; }
    }
}
