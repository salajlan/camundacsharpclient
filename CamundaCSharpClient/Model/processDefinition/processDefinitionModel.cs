using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.ProcessDefinition
{
    public class ProcessDefinitionModel : CamundaBase
    {
        public string Id { get; set; }

        public string Key { get; set; }

        public string Category { get; set; }

        public object Description { get; set; }

        public string Name { get; set; }

        public int Version { get; set; }

        public string Resource { get; set; }

        public string DeploymentId { get; set; }

        public string Diagram { get; set; }

        public bool Suspended { get; set; }
    }
}
