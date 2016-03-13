using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class HistoryVariableInstanceQueryModel
    {
        public enum SortByValues
        {
            instanceId,
            variableName,
        }

        public string variableName { get; set; }

        public string variableNameLike { get; set; }

        public string variableValue { get; set; }

        public string processInstanceId { get; set; }

        public string executionIdIn { get; set; }

        public string caseInstanceId { get; set; }

        public string caseExecutionIdIn { get; set; }

        public string taskIdIn { get; set; }

        public string activityInstanceIdIn { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }

        public int? firstResult { get; set; }

        public int? maxResults { get; set; }
    }
}
