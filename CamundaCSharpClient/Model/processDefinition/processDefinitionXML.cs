using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.ProcessDefinition
{
    public class ProcessDefinitionXML : CamundaBase
    {
        public string Id { get; set; }

        public string Bpmn20Xml { get; set; }
    }
}
