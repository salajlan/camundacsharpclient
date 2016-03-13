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
    public class HistoryVariableInstanceQuery : QueryBase
    {
        private HistoryVariableInstanceQueryModel model = new HistoryVariableInstanceQueryModel();

        public HistoryVariableInstanceQuery(CamundaRestClient client) : base(client)
        {
        }

        public HistoryVariableInstanceQuery VariableName(string variableName)
        {
            this.model.variableName = variableName;
            return this;
        }

        public HistoryVariableInstanceQuery VariableNameLike(string variableNameLike)
        {
            this.model.variableNameLike = variableNameLike;
            return this;
        }

        public HistoryVariableInstanceQuery VariableValue(string variableValue)
        {
            this.model.variableValue = variableValue;
            return this;
        }

        public HistoryVariableInstanceQuery ProcessInstanceId(string processInstanceId)
        {
            this.model.processInstanceId = processInstanceId;
            return this;
        }

        public HistoryVariableInstanceQuery executionIdIn(List<string> executionIdIn)
        {
            string executionIdInExtract = null;
            foreach (var item in executionIdIn)
            {
                executionIdInExtract += item + ",";
            }

            this.model.executionIdIn = executionIdInExtract;
            return this;
        }

        public HistoryVariableInstanceQuery caseInstanceId(string caseInstanceId)
        {
            this.model.caseInstanceId = caseInstanceId;
            return this;
        }

        public HistoryVariableInstanceQuery caseExecutionIdIn(List<string> caseExecutionIdIn)
        {
            string caseExecutionIdInExtract = null;
            foreach (var item in caseExecutionIdIn)
            {
                caseExecutionIdInExtract += item + ",";
            }

            this.model.caseExecutionIdIn = caseExecutionIdInExtract;
            return this;
        }

        public HistoryVariableInstanceQuery taskIdIn(List<string> taskIdIn)
        {
            string taskIdInExtract = null;
            foreach (var item in taskIdIn)
            {
                taskIdInExtract += item + ",";
            }

            this.model.taskIdIn = taskIdInExtract;
            return this;
        }

        public HistoryVariableInstanceQuery activityInstanceIdIn(List<string> activityInstanceIdIn)
        {
            string activityInstanceIdInExtract = null;
            foreach (var item in activityInstanceIdIn)
            {
                activityInstanceIdInExtract += item + ",";
            }

            this.model.variableName = activityInstanceIdInExtract;
            return this;
        }

        public HistoryVariableInstanceQuery SortByAndSortOrder(HistoryVariableInstanceQueryModel.SortByValues sortBy, string sortOrder)
        {
            this.model.sortBy = Enum.GetName(sortBy.GetType(), sortBy);
            this.model.sortOrder = sortOrder;
            return this;
        }

        public HistoryVariableInstanceQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public HistoryVariableInstanceQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }

        /// <summary>
        /// Query for historic variable instances that fulfill the given parameters
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// camundaCl.History().VariableInstance().VariableName("scheduleDate").List()
        /// </code>
        /// </example>
        public List<HistoryVariableInstanceModel> List()
        {
            var request = new RestRequest();
            request.Resource = "/history/variable-instance";
            return this.List<HistoryVariableInstanceModel>(QueryHelper.BuildQuery<HistoryVariableInstanceQueryModel>(this.model, request));
        }

        /// <summary>
        /// Query for historic variable instances that fulfill the given parameters
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// camundaCl.History().VariableInstance().VariableName("scheduleDate").Count()
        /// </code>
        /// </example>
        public Count Count()
        {
            var request = new RestRequest();
            request.Resource = "/history/variable-instance/count";
            return this.Count(QueryHelper.BuildQuery<HistoryVariableInstanceQueryModel>(this.model, request));
        }
    }
}
