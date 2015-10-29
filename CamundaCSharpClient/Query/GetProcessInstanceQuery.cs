using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;
using RestSharp;

namespace CamundaCSharpClient.Query
{
    public class GetProcessInstanceQuery :  queryBase
    {
        protected string maxResults { get; set; }

        protected string firstResult { get; set; }

        protected string sortOrder { get; set; }

        protected string sortBy { get; set; }

        protected string variables { get; set; }

        protected string incidentMessageLike { get; set; }

        protected string incidentMessage { get; set; }

        protected string incidentType { get; set; }

        protected string incidentId { get; set; }

        protected string suspended { get; set; }

        protected string active { get; set; }

        protected string subCaseInstance { get; set; }

        protected string superCaseInstance { get; set; }

        protected string subProcessInstance { get; set; }

        protected string superProcessInstance { get; set; }

        protected string processDefinitionKey { get; set; }

        protected string processDefinitionId { get; set; }

        protected string caseInstanceId { get; set; }

        protected string businessKey { get; set; }

        protected string processInstanceIds { get; set; }
        public GetProcessInstanceQuery ProcessInstanceIds(List<string> processInstanceIds)
        {
            string processInstanceIdsExtract = null;
            foreach (var item in processInstanceIds)
            {
                processInstanceIdsExtract += item + ",";
            }
            this.processInstanceIds = processInstanceIdsExtract;
            return this;
        }
        public GetProcessInstanceQuery BusinessKey(string businessKey)
        {
            this.businessKey = businessKey;
            return this;
        }
        public GetProcessInstanceQuery CaseInstanceId(string caseInstanceId)
        {
            this.caseInstanceId = caseInstanceId;
            return this;
        }
        public GetProcessInstanceQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.processDefinitionId = processDefinitionId;
            return this;
        }
        public GetProcessInstanceQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.processDefinitionKey = processDefinitionKey;
            return this;
        }
        public GetProcessInstanceQuery SuperProcessInstance(string superProcessInstance)
        {
            this.superProcessInstance = superProcessInstance;
            return this;
        }
        public GetProcessInstanceQuery SubProcessInstance(string subProcessInstance)
        {
            this.subProcessInstance = subProcessInstance;
            return this;
        }
        public GetProcessInstanceQuery SuperCaseInstance(string superCaseInstance)
        {
            this.superCaseInstance = superCaseInstance;
            return this;
        }
        public GetProcessInstanceQuery SubCaseInstance(string subCaseInstance)
        {
            this.subCaseInstance = subCaseInstance;
            return this;
        }
        public GetProcessInstanceQuery Active(bool active)
        {
            this.active = active.ToString().ToLower();
            return this;
        }
        public GetProcessInstanceQuery Suspended(bool suspended)
        {
            this.suspended = suspended.ToString().ToLower();
            return this;
        }
        public GetProcessInstanceQuery IncidentId(string incidentId)
        {
            this.incidentId = incidentId;
            return this;
        }
        public GetProcessInstanceQuery IncidentType(string incidentType)
        {
            this.incidentType = incidentType;
            return this;
        }
        public GetProcessInstanceQuery IncidentMessage(string incidentMessage)
        {
            this.incidentMessage = incidentMessage;
            return this;
        }
        public GetProcessInstanceQuery IncidentMessageLike(string incidentMessageLike)
        {
            this.incidentMessageLike = incidentMessageLike;
            return this;
        }
        public GetProcessInstanceQuery Variables(string variables)
        {
            this.variables = variables;
            return this;
        }
        public GetProcessInstanceQuery SortBy(string sortBy)
        {
            this.sortBy = sortBy;
            return this;
        }
        public GetProcessInstanceQuery SortOrder(string sortOrder)
        {
            this.sortOrder = sortOrder;
            return this;
        }
        public GetProcessInstanceQuery FirstResult(string firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }
        public GetProcessInstanceQuery MaxResults(string maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }

        public GetProcessInstanceQuery(camundaRestClient client) :base(client)
        { }

        public List<processInstance> list()
        {
            var request = new RestRequest();
            request.Resource = "/process-instance?" + new queryHelper().buildQuery<GetProcessInstanceQuery>(this);
            return list<processInstance>(request);
        }
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/process-instance/count?" + new queryHelper().buildQuery<GetProcessInstanceQuery>(this);
            return count(request);
        }
        
    }
}
