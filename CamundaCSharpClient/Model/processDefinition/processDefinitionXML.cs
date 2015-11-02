using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.processDefinition
{
    public class processDefinitionXML : camundaBase
    {
        public string id { get; set; }
        public string bpmn20Xml { get; set; }
    }
}
