using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Model.history;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Query.History
{
    public class HistoryProcessInstanceQuery : queryBase
    {
        protected string processInstanceId { get; set; }
        protected string processInstanceIds { get; set; }
        protected string processInstanceBusinessKey { get; set; }
        protected string processInstanceBusinessKeyLike { get; set; }
        protected string superProcessInstanceId { get; set; }
        protected string subProcessInstanceId { get; set; }
        protected string superCaseInstanceId { get; set; }
        protected string subCaseInstanceId { get; set; }
        protected string caseInstanceId { get; set; }
        protected string processDefinitionId { get; set; }
        protected string processDefinitionKey { get; set; }
        protected string processDefinitionKeyNotIn { get; set; }
        protected string processDefinitionNameLike { get; set; }
        protected string finished { get; set; }
        protected string unfinished { get; set; }
        protected string startedBy { get; set; }
        protected string startedBefore { get; set; }
        protected string startedAfter { get; set; }
        protected string finishedBefore { get; set; }
        protected string finishedAfter { get; set; }
        protected string variables { get; set; }
        protected string sortBy { get; set; }
        protected string sortOrder { get; set; }
        protected int? firstResult { get; set; }
        protected int? maxResults { get; set; }
        protected string processDefinitionName { get; set; }
        public HistoryProcessInstanceQuery(camundaRestClient client):base(client)
        { }

        public HistoryProcessInstanceQuery ProcessInstanceId(string processInstanceId)
        {
            this.processInstanceId = processInstanceId;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessInstanceIds(List<string> processInstanceIds)
        {
            string processInstanceIdsExtract = null;
            foreach (var item in processInstanceIds)
            {
                processInstanceIdsExtract += item + ",";
            }
            this.processInstanceIds = processInstanceIdsExtract;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessInstanceBusinessKey(string processInstanceBusinessKey)
        {
            this.processInstanceBusinessKey = processInstanceBusinessKey;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessInstanceBusinessKeyLike(string processInstanceBusinessKeyLike)
        {
            this.processInstanceBusinessKeyLike = processInstanceBusinessKeyLike;
            return this;
        }
        public HistoryProcessInstanceQuery SuperProcessInstanceId(string superProcessInstanceId)
        {
            this.superProcessInstanceId = superProcessInstanceId;
            return this;
        }
        public HistoryProcessInstanceQuery SubProcessInstanceId(string subProcessInstanceId)
        {
            this.subProcessInstanceId = subProcessInstanceId;
            return this;
        }
        public HistoryProcessInstanceQuery SuperCaseInstanceId(string superCaseInstanceId)
        {
            this.superCaseInstanceId = superCaseInstanceId;
            return this;
        }
        public HistoryProcessInstanceQuery SubCaseInstanceId(string subCaseInstanceId)
        {
            this.subCaseInstanceId = subCaseInstanceId;
            return this;
        }
        public HistoryProcessInstanceQuery CaseInstanceId(string caseInstanceId)
        {
            this.caseInstanceId = caseInstanceId;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.processDefinitionId = processDefinitionId;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.processDefinitionKey = processDefinitionKey;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessDefinitionKeyNotIn(List<string> processDefinitionKeyNotIn)
        {
            string processDefinitionKeyNotInExtract = null;
            foreach (var item in processDefinitionKeyNotIn)
            {
                processDefinitionKeyNotInExtract += item + ",";
            }
            this.processDefinitionKeyNotIn = processDefinitionKeyNotInExtract;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessDefinitionName(string processDefinitionName)
        {
            this.processDefinitionName = processDefinitionName;
            return this;
        }
        public HistoryProcessInstanceQuery ProcessDefinitionNameLike(string processDefinitionNameLike)
        {
            this.processDefinitionNameLike = processDefinitionNameLike;
            return this;
        }
        public HistoryProcessInstanceQuery Finished(bool finished)
        {
            this.finished = finished.ToString().ToLower();
            return this;
        }
        public HistoryProcessInstanceQuery Unfinished(bool unfinished)
        {
            this.unfinished = unfinished.ToString().ToLower();
            return this;
        }
        public HistoryProcessInstanceQuery StartedBy(string startedBy)
        {
            this.startedBy = startedBy;
            return this;
        }
        public HistoryProcessInstanceQuery StartedBefore(DateTime startedBefore)
        {
            this.startedBefore = startedBefore.ToString("s");
            return this;
        }
        public HistoryProcessInstanceQuery StartedAfter(DateTime startedAfter)
        {
            this.startedAfter = startedAfter.ToString("s");
            return this;
        }
        public HistoryProcessInstanceQuery FinishedBefore(DateTime finishedBefore)
        {
            this.finishedBefore = finishedBefore.ToString("s");
            return this;
        }
        public HistoryProcessInstanceQuery FinishedAfter(DateTime finishedAfter)
        {
            this.finishedAfter = finishedAfter.ToString("s");
            return this;
        }
        public HistoryProcessInstanceQuery Variables(string variables)
        {
            this.variables = variables;
            return this;
        }
        public HistoryProcessInstanceQuery SortByAndSortOrder(string sortBy,string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }
        public HistoryProcessInstanceQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }
        public HistoryProcessInstanceQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }
        /// <summary>
        /// Query for historic process instances that fulfill the given parameters.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi4 = camundaCl.History().ProcessInstance().ProcessDefinitionKey("invoice").StartedBy("salajlan").list();
        ///</code>
        ///</example>
        public List<HistoryProcessInstance> list()
        {
            var request = new RestRequest();
            request.Resource = "/history/process-instance";
            return list<HistoryProcessInstance>(new queryHelper().buildQuery<HistoryProcessInstanceQuery>(this, request));
        }
        /// <summary>
        /// Query for the number of historic process instances that fulfill the given parameters.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi3 = camundaCl.History().ProcessInstance().ProcessDefinitionKey("invoice").count();
        ///</code>
        ///</example>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/history/process-instance/count";
            return count(new queryHelper().buildQuery<HistoryProcessInstanceQuery>(this,request));
        }
        /// <summary>
        /// Retrieves a single historic process instance according to the HistoricProcessInstance interface in the engine.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi5 = camundaCl.History().ProcessInstance().ProcessInstanceId("09ece517-77ee-11e5-8af1-40a8f0a54b22").singleResult();
        ///</code>
        ///</example>
        public HistoryProcessInstance singleResult()
        {
            new EnsureHelper().ensureNotNull("ProcessInctanceId", this.processInstanceId);
            var request = new RestRequest();
            request.Resource = "/history/process-instance/"+this.processInstanceId;
            return singleResult<HistoryProcessInstance>(request);
        }

    }

}
