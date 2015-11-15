using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class HistoryProcessInstance : CamundaBase
    {
        public string BusinessKey { get; set; }

        public string CaseInstanceId { get; set; }

        public string DeleteReason { get; set; }

        public int DurationInMillis { get; set; }

        public string EndTime { get; set; }

        public string Id { get; set; }

        public string ProcessDefinitionId { get; set; }

        public string StartActivityId { get; set; }

        public string StartTime { get; set; }

        public string StartUserId { get; set; }

        public string SuperProcessInstanceId { get; set; }

        public string SuperCaseInstanceId { get; set; }
    }
}
