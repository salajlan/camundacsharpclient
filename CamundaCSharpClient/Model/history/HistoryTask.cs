using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class HistoryTask : CamundaBase
    {
        public string Id { get; set; }

        public string ProcessDefinitionId { get; set; }

        public string ProcessInstanceId { get; set; }

        public string ExecutionId { get; set; }

        public string CaseDefinitionId { get; set; }

        public string CaseInstanceId { get; set; }

        public string CaseExecutionId { get; set; }

        public string ActivityInstanceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DeleteReason { get; set; }

        public string Owner { get; set; }

        public string Assignee { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int Duration { get; set; }

        public string TaskDefinitionKey { get; set; }

        public int Priority { get; set; }

        public string Due { get; set; }

        public string ParentTaskId { get; set; }

        public string FollowUp { get; set; }
    }
}
