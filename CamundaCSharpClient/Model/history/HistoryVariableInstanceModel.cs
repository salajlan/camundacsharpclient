using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class HistoryVariableInstanceModel : CamundaBase
    {
        public string type { get; set; }

        public object value { get; set; }

        public string valueInfo { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public string processDefinitionKey { get; set; }

        public string processDefinitionId { get; set; }

        public string processInstanceId { get; set; }

        public string executionId { get; set; }

        public string activityInstanceId { get; set; }

        public object caseDefinitionKey { get; set; }

        public object caseDefinitionId { get; set; }

        public object caseInstanceId { get; set; }

        public object caseExecutionId { get; set; }

        public object taskId { get; set; }

        public object errorMessage { get; set; }
    }
}
