using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model.history;
using RestSharp;
using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model;

namespace CamundaCSharpClient.Query.History
{
    public class DetailsQuery : queryBase
    {
        protected string processInstanceId { get; set; }

        protected string activityInstanceId { get; set; }

        protected string executionId { get; set; }

        protected string caseInstanceId { get; set; }

        protected string caseExecutionId { get; set; }

        protected string variableInstanceId { get; set; }

        protected string formFields { get; set; }

        protected string variableUpdates { get; set; }

        protected string excludeTaskDetails { get; set; }

        protected string sortBy { get; set; }

        protected string sortOrder { get; set; }

        protected int? firstResult { get; set; }

        protected int? maxResults { get; set; }

        public DetailsQuery(camundaRestClient client):base(client)
        { }


        public DetailsQuery ProcessInstanceId(string processInstanceId)
        {
            this.processInstanceId = processInstanceId;
            return this;
        }
        public DetailsQuery ActivityInstanceId(string activityInstanceId)
        {
            this.activityInstanceId = activityInstanceId;
            return this;
        }
        public DetailsQuery ExecutionId(string executionId)
        {
            this.executionId = executionId;
            return this;
        }
        public DetailsQuery CaseInstanceId(string caseInstanceId)
        {
            this.caseInstanceId = caseInstanceId;
            return this;
        }
        public DetailsQuery CaseExecutionId(string caseExecutionId)
        {
            this.caseExecutionId = caseExecutionId;
            return this;
        }
        public DetailsQuery VariableInstanceId(string variableInstanceId)
        {
            this.variableInstanceId = variableInstanceId;
            return this;
        }
        public DetailsQuery FormFields(bool formFields)
        {
            this.formFields = formFields.ToString().ToLower();
            return this;
        }
        public DetailsQuery VariableUpdates(bool variableUpdates)
        {
            this.variableUpdates = variableUpdates.ToString().ToLower();
            return this;
        }
        public DetailsQuery ExcludeTaskDetails(bool excludeTaskDetails)
        {
            this.excludeTaskDetails = excludeTaskDetails.ToString().ToLower();
            return this;
        }
        public DetailsQuery SortByNsortOrder(string sortBy, string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }
        public DetailsQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }
        public DetailsQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }
        /// <summary>
        /// Query for historic details that fulfill the given parameters. The size of the result set can be retrieved by using the count method.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi2 = camundaCl.History().Details().ProcessInstanceId("14cc53f0-8067-11e5-ac78-40a8f0a54b22").VariableUpdates(true).list();
        ///</code>
        ///</example>
        /// <returns></returns>

        public List<HistoricDetails> list()
        {
            var request = new RestRequest();
            request.Resource = "/history/detail";
            var parms = new queryHelper().buildQuery<DetailsQuery>(this);
            foreach (var item in parms)
            {
                request.AddParameter(item);
            }
            return list<HistoricDetails>(request);
        }
        /// <summary>
        /// Query for the number of historic details that fulfill the given parameters. Takes the same parameters as the get historic details method
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi = camundaCl.History().Details().ProcessInstanceId("14cc53f0-8067-11e5-ac78-40a8f0a54b22").count();
        ///</code>
        ///</example>
        /// <returns>Count</returns>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/history/detail/count";
            var parms = new queryHelper().buildQuery<DetailsQuery>(this);
            foreach (var item in parms)
            {
                request.AddParameter(item);
            }
            return count(request);
        }

        
    }
}
