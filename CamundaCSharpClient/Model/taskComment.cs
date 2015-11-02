using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class taskComment : camundaBase
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string taskId { get; set; }
        public string time { get; set; }
        public string message { get; set; }
    }
}
