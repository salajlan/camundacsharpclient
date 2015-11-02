using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.history
{
    public class HistoryTask : camundaBase
    {
        public string id { get; set; }
        public string processDefinitionId { get; set; }
        public string processInstanceId { get; set; }
        public string executionId { get; set; }
        public string caseDefinitionId { get; set; }
        public string caseInstanceId { get; set; }
        public string caseExecutionId { get; set; }
        public string activityInstanceId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string deleteReason { get; set; }
        public string owner { get; set; }
        public string assignee { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int duration { get; set; }
        public string taskDefinitionKey { get; set; }
        public int priority { get; set; }
        public string due { get; set; }
        public string parentTaskId { get; set; }
        public string followUp { get; set; }
    }
}
