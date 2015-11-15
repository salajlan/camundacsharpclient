using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class processInstance : CamundaBase
    {
        public string Id { get; set; }

        public string DefinitionId { get; set; }

        public string BusinessKey { get; set; }

        public object CaseInstanceId { get; set; }

        public bool Ended { get; set; }

        public bool Suspended { get; set; }

        public object Links { get; set; }
    }
}
