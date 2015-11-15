using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class Group : CamundaBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
