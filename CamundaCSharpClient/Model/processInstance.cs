using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class processInstance : camundaBase
    {
        public string id { get; set; }
        public string definitionId { get; set; }
        public string businessKey { get; set; }
        public object caseInstanceId { get; set; }
        public bool ended { get; set; }
        public bool suspended { get; set; }
        public object links { get; set; }
    }
}
