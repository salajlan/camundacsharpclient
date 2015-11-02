using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.history
{
    public class HistoryProcessInstance : camundaBase
    {
        public string businessKey { get; set; }
        public string caseInstanceId { get; set; }
        public string deleteReason { get; set; }
        public int durationInMillis { get; set; }
        public string endTime { get; set; }
        public string id { get; set; }
        public string processDefinitionId { get; set; }
        public string startActivityId { get; set; }
        public string startTime { get; set; }
        public string startUserId { get; set; }
        public string superProcessInstanceId { get; set; }
        public string superCaseInstanceId { get; set; }
    }
}
