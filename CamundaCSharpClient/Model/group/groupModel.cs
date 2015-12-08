using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.Group
{
    public class GroupModel : CamundaBase
    {
        public string id { get; set; }

        public string name { get; set; }

        public string type { get; set; }
    }
}
