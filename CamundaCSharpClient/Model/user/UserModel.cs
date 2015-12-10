using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.Task
{
    public class UserModel : CamundaBase
    {
        public string id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }
    }
}
