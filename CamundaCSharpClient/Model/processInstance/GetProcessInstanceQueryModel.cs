using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.ProcessInstance
{
    public class GetProcessInstanceQueryModel
    {
        public enum SortByValue
        {
            instanceId,
            definitionKey,
            definitionId
        }

        public int? maxResults { get; set; }

        public int? firstResult { get; set; }

        public string sortOrder { get; set; }

        public string sortBy { get; set; }

        public string variables { get; set; }

        public string incidentMessageLike { get; set; }

        public string incidentMessage { get; set; }

        public string incidentType { get; set; }

        public string incidentId { get; set; }

        public string suspended { get; set; }

        public string active { get; set; }

        public string subCaseInstance { get; set; }

        public string superCaseInstance { get; set; }

        public string subProcessInstance { get; set; }

        public string superProcessInstance { get; set; }

        public string processDefinitionKey { get; set; }

        public string processDefinitionId { get; set; }

        public string caseInstanceId { get; set; }

        public string businessKey { get; set; }

        public string processInstanceIds { get; set; }
    }
}
