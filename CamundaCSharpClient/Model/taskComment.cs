using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class TaskComment : CamundaBase
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string TaskId { get; set; }

        public string Time { get; set; }

        public string Message { get; set; }
    }
}
