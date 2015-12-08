using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.ProcessDefinition
{
    public class ProcessDefinitionSuspendModel : CamundaBase
    {
        public bool Suspended { get; set; }

        public bool IncludeProcessInstances { get; set; }

        public DateTime ExecutionDate { get; set; }
    }
}
