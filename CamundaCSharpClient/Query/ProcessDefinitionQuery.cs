using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;
using RestSharp;
using Newtonsoft.Json;

namespace CamundaCSharpClient.Query
{
    public class ProcessDefinitionQuery : queryBase
    {
        protected string id { get; set; }

        protected string name { get; set; }

        protected string nameLike { get; set; }

        protected string deploymentId { get; set; }

        protected string key { get; set; }

        protected string keyLike { get; set; }

        protected string category { get; set; }

        protected string categoryLike { get; set; }

        protected int? version { get; set; }

        protected string latestVersion { get; set; }

        protected string resourceName { get; set; }

        protected string resourceNameLike { get; set; }

        protected string startableBy { get; set; }

        protected string active { get; set; }

        protected string suspended { get; set; }

        protected string incidentId { get; set; }

        protected string incidentType { get; set; }

        protected string incidentMessage { get; set; }

        protected string incidentMessageLike { get; set; }

        protected int? firstResult { get; set; }

        protected int? maxResults { get; set; }

        protected string sortBy { get; set; }

        protected string sortOrder { get; set; }
        protected string caseInstanceId { get; set; }
        protected string businessKey { get; set; }
        EnsureHelper ensure = null;

        public ProcessDefinitionQuery Id(string id)
        {
            this.id = id;
            return this;
        }
        public ProcessDefinitionQuery Name(string name)
        {
            this.name = name;
            return this;
        }
        public ProcessDefinitionQuery BusinessKey(string businessKey)
        {
            this.businessKey = businessKey;
            return this;
        }
        public ProcessDefinitionQuery CaseInstanceId(string caseInstanceId)
        {
            this.caseInstanceId = caseInstanceId;
            return this;
        }
        public ProcessDefinitionQuery NameLike(string nameLike)
        {
            this.nameLike = nameLike;
            return this;
        }
        public ProcessDefinitionQuery DeploymentId(string deploymentId)
        {
            this.deploymentId = deploymentId;
            return this;
        }
        public ProcessDefinitionQuery Key(string key)
        {
            this.key = key;
            return this;
        }
        public ProcessDefinitionQuery KeyLike(string keyLike)
        {
            this.keyLike = keyLike ;
            return this;
        }
        public ProcessDefinitionQuery Category(string category)
        {
            this.category = category;
            return this;
        }
        public ProcessDefinitionQuery CategoryLike(string categoryLike)
        {
            this.categoryLike = categoryLike;
            return this;
        }
        public ProcessDefinitionQuery Version(int version)
        {
            this.version = version;
            return this;
        }
        public ProcessDefinitionQuery LatestVersion(bool latestVersion)
        {
            this.latestVersion = latestVersion.ToString().ToLower();
            return this;
        }
        public ProcessDefinitionQuery ResourceName(string resourceName)
        {
            this.resourceName = resourceName;
            return this;
        }
        public ProcessDefinitionQuery ResourceNameLike(string resourceNameLike)
        {
            this.resourceNameLike = resourceNameLike;
            return this;
        }
        public ProcessDefinitionQuery StartableBy(string startableBy)
        {
            this.startableBy = startableBy;
            return this;
        }
        public ProcessDefinitionQuery Active(bool active)
        {
            this.active = active.ToString().ToLower();
            return this;
        }
        public ProcessDefinitionQuery Suspended(bool suspended)
        {
            this.suspended = suspended.ToString().ToLower();
            return this;
        }
        public ProcessDefinitionQuery IncidentId(string incidentId)
        {
            this.incidentId = incidentId;
            return this;
        }
        public ProcessDefinitionQuery IncidentType(string incidentType)
        {
            this.incidentType = incidentType;
            return this;
        }
        public ProcessDefinitionQuery IncidentMessage(string incidentMessage)
        {
            this.incidentMessage = incidentMessage;
            return this;
        }
        public ProcessDefinitionQuery IncidentMessageLike(string incidentMessageLike)
        {
            this.incidentMessageLike = incidentMessageLike;
            return this;
        }
        public ProcessDefinitionQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }
        public ProcessDefinitionQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }
        public ProcessDefinitionQuery SortByNSortOrder(string sortBy, string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }

        public ProcessDefinitionQuery(camundaRestClient client) :base(client)
        {
            this.ensure = new EnsureHelper();
        }

        public List<processDefinition> list()
        {
            var request = new RestRequest();
            request.Resource = "/process-definition?" + new queryHelper().buildQuery<ProcessDefinitionQuery>(this);
            return list<processDefinition>(request);
        }
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/process-definition/count?" + new queryHelper().buildQuery<ProcessDefinitionQuery>(this);
            return count(request);
        }

        public processDefinitionXML Xml()
        {
            var request = new RestRequest();
            if (this.id != null) request.Resource = "/process-definition/"+this.id+"/xml";
            else
            {
                this.ensure.ensureNotNull("processDefiniftionKey", this.key);
                request.Resource = "/process-definition/key/" + this.key + "/xml";
            }
            return client.Execute<processDefinitionXML>(request);
        }

        public processInstance start<T>(T variables)
        {
            this.ensure.ensureNotNull("processDefinitionVariables", variables);
            var request = new RestRequest();
            if (this.id != null) request.Resource = "/process-definition/" + this.id + "/start";
            else
            {
                this.ensure.ensureNotNull("processDefiniftionKey", this.key);
                request.Resource = "/process-definition/key/" + this.key + "/start";
            }

            request.Method = Method.POST;
            object obj = new { variables, this.businessKey, this.caseInstanceId };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            return client.Execute<processInstance>(request);
        }        
    }
}
