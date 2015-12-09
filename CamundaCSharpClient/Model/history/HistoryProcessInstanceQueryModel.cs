using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class HistoryProcessInstanceQueryModel
    {
        public enum SortByValue
        {
             instanceId,
             definitionId,
             businessKey,
             startTime,
             duration,
             endTime             
        }

        public string processInstanceId { get; set; }

        public string processInstanceIds { get; set; }

        public string processInstanceBusinessKey { get; set; }

        public string processInstanceBusinessKeyLike { get; set; }

        public string superProcessInstanceId { get; set; }

        public string subProcessInstanceId { get; set; }

        public string superCaseInstanceId { get; set; }

        public string subCaseInstanceId { get; set; }

        public string caseInstanceId { get; set; }

        public string processDefinitionId { get; set; }

        public string processDefinitionKey { get; set; }

        public string processDefinitionKeyNotIn { get; set; }

        public string processDefinitionNameLike { get; set; }

        public string finished { get; set; }

        public string unfinished { get; set; }

        public string startedBy { get; set; }

        public string startedBefore { get; set; }

        public string startedAfter { get; set; }

        public string finishedBefore { get; set; }

        public string finishedAfter { get; set; }

        public string variables { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }

        public int? firstResult { get; set; }

        public int? maxResults { get; set; }

        public string processDefinitionName { get; set; }
    }
}
