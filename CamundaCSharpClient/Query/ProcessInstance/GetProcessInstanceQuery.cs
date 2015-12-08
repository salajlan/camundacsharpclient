using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;
using RestSharp;

namespace CamundaCSharpClient.Query.ProcessInstance
{
    public class GetProcessInstanceQuery : QueryBase
    {
        private GetProcessInstanceQueryModel model = new GetProcessInstanceQueryModel();

        public GetProcessInstanceQuery(CamundaRestClient client)
            : base(client)
        {
        }        

        public GetProcessInstanceQuery ProcessInstanceIds(List<string> processInstanceIds)
        {
            string processInstanceIdsExtract = null;
            foreach (var item in processInstanceIds)
            {
                processInstanceIdsExtract += item + ",";
            }

            this.model.processInstanceIds = processInstanceIdsExtract;
            return this;
        }

        public GetProcessInstanceQuery BusinessKey(string businessKey)
        {
            this.model.businessKey = businessKey;
            return this;
        }

        public GetProcessInstanceQuery CaseInstanceId(string caseInstanceId)
        {
            this.model.caseInstanceId = caseInstanceId;
            return this;
        }

        public GetProcessInstanceQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.model.processDefinitionId = processDefinitionId;
            return this;
        }

        public GetProcessInstanceQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.model.processDefinitionKey = processDefinitionKey;
            return this;
        }

        public GetProcessInstanceQuery SuperProcessInstance(string superProcessInstance)
        {
            this.model.superProcessInstance = superProcessInstance;
            return this;
        }

        public GetProcessInstanceQuery SubProcessInstance(string subProcessInstance)
        {
            this.model.subProcessInstance = subProcessInstance;
            return this;
        }

        public GetProcessInstanceQuery SuperCaseInstance(string superCaseInstance)
        {
            this.model.superCaseInstance = superCaseInstance;
            return this;
        }

        public GetProcessInstanceQuery SubCaseInstance(string subCaseInstance)
        {
            this.model.subCaseInstance = subCaseInstance;
            return this;
        }

        public GetProcessInstanceQuery Active(bool active)
        {
            this.model.active = active.ToString().ToLower();
            return this;
        }

        public GetProcessInstanceQuery Suspended(bool suspended)
        {
            this.model.suspended = suspended.ToString().ToLower();
            return this;
        }

        public GetProcessInstanceQuery IncidentId(string incidentId)
        {
            this.model.incidentId = incidentId;
            return this;
        }

        public GetProcessInstanceQuery IncidentType(string incidentType)
        {
            this.model.incidentType = incidentType;
            return this;
        }

        public GetProcessInstanceQuery IncidentMessage(string incidentMessage)
        {
            this.model.incidentMessage = incidentMessage;
            return this;
        }

        public GetProcessInstanceQuery IncidentMessageLike(string incidentMessageLike)
        {
            this.model.incidentMessageLike = incidentMessageLike;
            return this;
        }

        public GetProcessInstanceQuery Variables(string variables)
        {
            this.model.variables = variables;
            return this;
        }

        public GetProcessInstanceQuery SortByNSortOrder(string sortBy, string sortOrder)
        {
            this.model.sortBy = sortBy;
            this.model.sortOrder = sortOrder;
            return this;
        }

        public GetProcessInstanceQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public GetProcessInstanceQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }        

        public List<processInstance> list()
        {
            var request = new RestRequest();
            request.Resource = "/process-instance";
            return this.List<processInstance>(new QueryHelper().BuildQuery<GetProcessInstanceQueryModel>(this.model, request));
        }

        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/process-instance/count";
            return this.Count(new QueryHelper().BuildQuery<GetProcessInstanceQueryModel>(this.model, request));
        }        
    }
}
