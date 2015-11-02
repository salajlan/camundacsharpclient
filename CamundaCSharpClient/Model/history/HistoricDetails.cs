using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.history
{
    public class HistoricDetails : camundaBase
    {
        public string id { get; set; }
        public string processInstanceId { get; set; }
        public string activityInstanceId { get; set; }
        public string executionId { get; set; }
        public object caseInstanceId { get; set; }
        public object caseExecutionId { get; set; }
        public string time { get; set; }
        public string variableName { get; set; }
        public string variableInstanceId { get; set; }
        public string variableType { get; set; }
        public string value { get; set; }
        public int revision { get; set; }
        public string errorMessage { get; set; }
        public string fieldId { get; set; }
        public string fieldValue { get; set; }
    }
}
