using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class ProcessInstanceQueryModel
    {
        public string id { get; set; }

        public string varId { get; set; }

        public string deserializeValues { get; set; }

        public string suspended { get; set; }

        public string processDefinitionId { get; set; }

        public string processDefinitionKey { get; set; }
    }
}
