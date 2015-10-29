using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class processDefinitionSuspend
    {
        public bool suspended { get; set; }
        public bool includeProcessInstances { get; set; }
        public DateTime executionDate { get; set; }
    }
}
