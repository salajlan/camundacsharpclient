using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class HistoryDetailsModel : CamundaBase
    {
        public string Id { get; set; }

        public string ProcessInstanceId { get; set; }

        public string ActivityInstanceId { get; set; }

        public string ExecutionId { get; set; }

        public object CaseInstanceId { get; set; }

        public object CaseExecutionId { get; set; }

        public string Time { get; set; }

        public string VariableName { get; set; }

        public string VariableInstanceId { get; set; }

        public string VariableType { get; set; }

        public string Value { get; set; }

        public int Revision { get; set; }

        public string ErrorMessage { get; set; }

        public string FieldId { get; set; }

        public string FieldValue { get; set; }
    }
}
