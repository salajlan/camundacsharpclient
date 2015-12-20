using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model.History;
using RestSharp;
using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model;

namespace CamundaCSharpClient.Query.History
{
    public class DetailsQuery : QueryBase
    {
        private DetailsQueryModel model = new DetailsQueryModel();

        public DetailsQuery(CamundaRestClient client) : base(client)
        { 
        }        
        
        public DetailsQuery ProcessInstanceId(string processInstanceId)
        {
            this.model.processInstanceId = processInstanceId;
            return this;
        }

        public DetailsQuery ActivityInstanceId(string activityInstanceId)
        {
            this.model.activityInstanceId = activityInstanceId;
            return this;
        }

        public DetailsQuery ExecutionId(string executionId)
        {
            this.model.executionId = executionId;
            return this;
        }

        public DetailsQuery CaseInstanceId(string caseInstanceId)
        {
            this.model.caseInstanceId = caseInstanceId;
            return this;
        }

        public DetailsQuery CaseExecutionId(string caseExecutionId)
        {
            this.model.caseExecutionId = caseExecutionId;
            return this;
        }

        public DetailsQuery VariableInstanceId(string variableInstanceId)
        {
            this.model.variableInstanceId = variableInstanceId;
            return this;
        }

        public DetailsQuery FormFields(bool formFields)
        {
            this.model.formFields = formFields.ToString().ToLower();
            return this;
        }

        public DetailsQuery VariableUpdates(bool variableUpdates)
        {
            this.model.variableUpdates = variableUpdates.ToString().ToLower();
            return this;
        }

        public DetailsQuery ExcludeTaskDetails(bool excludeTaskDetails)
        {
            this.model.excludeTaskDetails = excludeTaskDetails.ToString().ToLower();
            return this;
        }

        public DetailsQuery SortByNsortOrder(DetailsQueryModel.SortByValues sortBy, string sortOrder)
        {
            this.model.sortBy = Enum.GetName(sortBy.GetType(), sortBy);
            this.model.sortOrder = sortOrder;
            return this;
        }

        public DetailsQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public DetailsQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }

        /// <summary>
        /// Query for historic details that fulfill the given parameters. The size of the result set can be retrieved by using the count method.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi2 = camundaCl.History().Details().ProcessInstanceId("14cc53f0-8067-11e5-ac78-40a8f0a54b22").VariableUpdates(true).list();
        /// </code>
        /// </example>
        public List<HistoryDetailsModel> List()
        {
            var request = new RestRequest();
            request.Resource = "/history/detail";
            return this.List<HistoryDetailsModel>(QueryHelper.BuildQuery<DetailsQueryModel>(this.model, request));
        }

        /// <summary>
        /// Query for the number of historic details that fulfill the given parameters. Takes the same parameters as the get historic details method
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi = camundaCl.History().Details().ProcessInstanceId("14cc53f0-8067-11e5-ac78-40a8f0a54b22").count();
        /// </code>
        /// </example>
        /// <returns>Count</returns>
        public Count Count()
        {
            var request = new RestRequest();
            request.Resource = "/history/detail/count";
            return this.Count(QueryHelper.BuildQuery<DetailsQueryModel>(this.model, request));
        }
    }
}
