using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Model.History;
using RestSharp;

namespace CamundaCSharpClient.Query.History
{
    public class HistoryProcessInstanceQuery : QueryBase
    {
        private HistoryProcessInstanceQueryModel model = new HistoryProcessInstanceQueryModel();

        public HistoryProcessInstanceQuery(CamundaRestClient client) : base(client)
        {
        }

        public HistoryProcessInstanceQuery ProcessInstanceId(string processInstanceId)
        {
            this.model.processInstanceId = processInstanceId;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessInstanceIds(List<string> processInstanceIds)
        {
            string processInstanceIdsExtract = null;
            foreach (var item in processInstanceIds)
            {
                processInstanceIdsExtract += item + ",";
            }

            this.model.processInstanceIds = processInstanceIdsExtract;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessInstanceBusinessKey(string processInstanceBusinessKey)
        {
            this.model.processInstanceBusinessKey = processInstanceBusinessKey;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessInstanceBusinessKeyLike(string processInstanceBusinessKeyLike)
        {
            this.model.processInstanceBusinessKeyLike = processInstanceBusinessKeyLike;
            return this;
        }

        public HistoryProcessInstanceQuery SuperProcessInstanceId(string superProcessInstanceId)
        {
            this.model.superProcessInstanceId = superProcessInstanceId;
            return this;
        }

        public HistoryProcessInstanceQuery SubProcessInstanceId(string subProcessInstanceId)
        {
            this.model.subProcessInstanceId = subProcessInstanceId;
            return this;
        }

        public HistoryProcessInstanceQuery SuperCaseInstanceId(string superCaseInstanceId)
        {
            this.model.superCaseInstanceId = superCaseInstanceId;
            return this;
        }

        public HistoryProcessInstanceQuery SubCaseInstanceId(string subCaseInstanceId)
        {
            this.model.subCaseInstanceId = subCaseInstanceId;
            return this;
        }

        public HistoryProcessInstanceQuery CaseInstanceId(string caseInstanceId)
        {
            this.model.caseInstanceId = caseInstanceId;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.model.processDefinitionId = processDefinitionId;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.model.processDefinitionKey = processDefinitionKey;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessDefinitionKeyNotIn(List<string> processDefinitionKeyNotIn)
        {
            string processDefinitionKeyNotInExtract = null;
            foreach (var item in processDefinitionKeyNotIn)
            {
                processDefinitionKeyNotInExtract += item + ",";
            }

            this.model.processDefinitionKeyNotIn = processDefinitionKeyNotInExtract;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessDefinitionName(string processDefinitionName)
        {
            this.model.processDefinitionName = processDefinitionName;
            return this;
        }

        public HistoryProcessInstanceQuery ProcessDefinitionNameLike(string processDefinitionNameLike)
        {
            this.model.processDefinitionNameLike = processDefinitionNameLike;
            return this;
        }

        public HistoryProcessInstanceQuery Finished(bool finished)
        {
            this.model.finished = finished.ToString().ToLower();
            return this;
        }

        public HistoryProcessInstanceQuery Unfinished(bool unfinished)
        {
            this.model.unfinished = unfinished.ToString().ToLower();
            return this;
        }

        public HistoryProcessInstanceQuery StartedBy(string startedBy)
        {
            this.model.startedBy = startedBy;
            return this;
        }

        public HistoryProcessInstanceQuery StartedBefore(DateTime startedBefore)
        {
            this.model.startedBefore = startedBefore.ToString("s");
            return this;
        }

        public HistoryProcessInstanceQuery StartedAfter(DateTime startedAfter)
        {
            this.model.startedAfter = startedAfter.ToString("s");
            return this;
        }

        public HistoryProcessInstanceQuery FinishedBefore(DateTime finishedBefore)
        {
            this.model.finishedBefore = finishedBefore.ToString("s");
            return this;
        }

        public HistoryProcessInstanceQuery FinishedAfter(DateTime finishedAfter)
        {
            this.model.finishedAfter = finishedAfter.ToString("s");
            return this;
        }

        public HistoryProcessInstanceQuery Variables(string variables)
        {
            this.model.variables = variables;
            return this;
        }

        public HistoryProcessInstanceQuery SortByAndSortOrder(string sortBy, string sortOrder)
        {
            this.model.sortBy = sortBy;
            this.model.sortOrder = sortOrder;
            return this;
        }

        public HistoryProcessInstanceQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public HistoryProcessInstanceQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }

        /// <summary>
        /// Query for historic process instances that fulfill the given parameters.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi4 = camundaCl.History().ProcessInstance().ProcessDefinitionKey("invoice").StartedBy("salajlan").list();
        /// </code>
        /// </example>
        public List<HistoryProcessInstanceModel> list()
        {
            var request = new RestRequest();
            request.Resource = "/history/process-instance";
            return this.List<HistoryProcessInstanceModel>(new QueryHelper().BuildQuery<HistoryProcessInstanceQueryModel>(this.model, request));
        }

        /// <summary>
        /// Query for the number of historic process instances that fulfill the given parameters.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi3 = camundaCl.History().ProcessInstance().ProcessDefinitionKey("invoice").count();
        /// </code>
        /// </example>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/history/process-instance/count";
            return this.Count(new QueryHelper().BuildQuery<HistoryProcessInstanceQueryModel>(this.model, request));
        }

        /// <summary>
        /// Retrieves a single historic process instance according to the HistoricProcessInstance interface in the engine.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi5 = camundaCl.History().ProcessInstance().ProcessInstanceId("09ece517-77ee-11e5-8af1-40a8f0a54b22").singleResult();
        /// </code>
        /// </example>
        public HistoryProcessInstanceModel singleResult()
        {
            new EnsureHelper().NotNull("ProcessInctanceId", this.model.processInstanceId);
            var request = new RestRequest();
            request.Resource = "/history/process-instance/" + this.model.processInstanceId;
            return this.SingleResult<HistoryProcessInstanceModel>(request);
        }
    }
}
