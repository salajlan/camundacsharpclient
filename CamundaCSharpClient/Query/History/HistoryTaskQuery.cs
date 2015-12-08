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
    public class HistoryTaskQuery : QueryBase
    {
        private HistoryTaskQueryModel model = new HistoryTaskQueryModel();

        public HistoryTaskQuery(CamundaRestClient client)
            : base(client)
        {
        }        

        public HistoryTaskQuery TaskId(string taskId)
        {
            this.model.taskId = taskId;
            return this;
        }

        public HistoryTaskQuery TaskParentTaskId(string taskParentTaskId)
        {
            this.model.taskParentTaskId = taskParentTaskId;
            return this;
        }

        public HistoryTaskQuery ProcessInstanceId(string processInstanceId)
        {
            this.model.processInstanceId = processInstanceId;
            return this;
        }

        public HistoryTaskQuery ExecutionId(string executionId)
        {
            this.model.executionId = executionId;
            return this;
        }

        public HistoryTaskQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.model.processDefinitionId = processDefinitionId;
            return this;
        }

        public HistoryTaskQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.model.processDefinitionKey = processDefinitionKey;
            return this;
        }

        public HistoryTaskQuery ProcessDefinitionName(string processDefinitionName)
        {
            this.model.processDefinitionName = processDefinitionName;
            return this;
        }

        public HistoryTaskQuery CaseInstanceId(string caseInstanceId)
        {
            this.model.caseInstanceId = caseInstanceId;
            return this;
        }

        public HistoryTaskQuery CaseExecutionId(string caseExecutionId)
        {
            this.model.caseExecutionId = caseExecutionId;
            return this;
        }

        public HistoryTaskQuery CaseDefinitionId(string caseDefinitionId)
        {
            this.model.caseDefinitionId = caseDefinitionId;
            return this;
        }

        public HistoryTaskQuery CaseDefinitionKey(string caseDefinitionKey)
        {
            this.model.caseDefinitionKey = caseDefinitionKey;
            return this;
        }

        public HistoryTaskQuery CaseDefinitionName(string caseDefinitionName)
        {
            this.model.caseDefinitionName = caseDefinitionName;
            return this;
        }

        public HistoryTaskQuery ActivityInstanceIdIn(List<string> activityInstanceIdIn)
        {
            string activityInstanceIdInExtract = null;  
            foreach (var item in activityInstanceIdIn)
            {
                activityInstanceIdInExtract += item + ",";
            }

            this.model.activityInstanceIdIn = activityInstanceIdInExtract;
            return this;
        }

        public HistoryTaskQuery TaskName(string taskName)
        {
            this.model.taskName = taskName;
            return this;
        }

        public HistoryTaskQuery TaskNameLike(string taskNameLike)
        {
            this.model.taskNameLike = taskNameLike;
            return this;
        }

        public HistoryTaskQuery TaskDescription(string taskDescription)
        {
            this.model.taskDescription = taskDescription;
            return this;
        }

        public HistoryTaskQuery TaskDescriptionLike(string taskDescriptionLike)
        {
            this.model.taskDescriptionLike = taskDescriptionLike;
            return this;
        }

        public HistoryTaskQuery TaskDefinitionKey(string taskDefinitionKey)
        {
            this.model.taskDefinitionKey = taskDefinitionKey;
            return this;
        }

        public HistoryTaskQuery TaskDeleteReason(string taskDeleteReason)
        {
            this.model.taskDeleteReason = taskDeleteReason;
            return this;
        }

        public HistoryTaskQuery TaskDeleteReasonLike(string taskDeleteReasonLike)
        {
            this.model.taskDeleteReasonLike = taskDeleteReasonLike;
            return this;
        }

        public HistoryTaskQuery TaskAssignee(string taskAssignee)
        {
            this.model.taskAssignee = taskAssignee;
            return this;
        }

        public HistoryTaskQuery TaskAssigneeLike(string taskAssigneeLike)
        {
            this.model.taskAssigneeLike = taskAssigneeLike;
            return this;
        }

        public HistoryTaskQuery TaskOwner(string taskOwner)
        {
            this.model.taskOwner = taskOwner;
            return this;
        }

        public HistoryTaskQuery TaskOwnerLike(string taskOwnerLike)
        {
            this.model.taskOwnerLike = taskOwnerLike;
            return this;
        }

        public HistoryTaskQuery TaskPriority(string taskPriority)
        {
            this.model.taskPriority = taskPriority;
            return this;
        }

        public HistoryTaskQuery Finished(bool finished)
        {
            this.model.finished = finished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery Unfinished(bool unfinished)
        {
            this.model.unfinished = unfinished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery ProcessFinished(bool processFinished)
        {
            this.model.processFinished = processFinished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery ProcessUnfinished(bool processUnfinished)
        {
            this.model.processUnfinished = processUnfinished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery TaskDueDate(DateTime taskDueDate)
        {
            this.model.taskDueDate = taskDueDate.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskDueDateBefore(DateTime taskDueDateBefore)
        {
            this.model.taskDueDateBefore = taskDueDateBefore.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskDueDateAfter(DateTime taskDueDateAfter)
        {
            this.model.taskDueDateAfter = taskDueDateAfter.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskFollowUpDate(DateTime taskFollowUpDate)
        {
            this.model.taskFollowUpDate = taskFollowUpDate.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskFollowUpDateBefore(DateTime taskFollowUpDateBefore)
        {
            this.model.taskFollowUpDateBefore = taskFollowUpDateBefore.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskFollowUpDateAfter(DateTime taskFollowUpDateAfter)
        {
            this.model.taskFollowUpDateAfter = taskFollowUpDateAfter.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskVariables(string taskVariables)
        {
            this.model.taskVariables = taskVariables;
            return this;
        }

        public HistoryTaskQuery ProcessVariables(string processVariables)
        {
            this.model.processVariables = processVariables;
            return this;
        }

        public HistoryTaskQuery SortByAndSortOrder(string sortBy, string sortOrder)
        {
            this.model.sortBy = sortBy;
            this.model.sortOrder = sortOrder;
            return this;
        }

        public HistoryTaskQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public HistoryTaskQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }        

        /// <summary>
        /// Query for historic tasks that fulfill the given parameters
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi7 = camundaCl.History().Task().Unfinished(true).TaskDueDateAfter(DateTime.Now).list();
        /// </code>
        /// </example>
        public List<HistoryTaskModel> List()
        {
            var request = new RestRequest();
            request.Resource = "/history/task";
            return this.List<HistoryTaskModel>(new QueryHelper().BuildQuery<HistoryTaskQueryModel>(this.model, request));
        }

        /// <summary>
        /// Query for the number of historic tasks that fulfill the given parameters
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var hi6 = camundaCl.History().Task().Finished(true).TaskDueDateAfter(DateTime.Now).count();
        /// </code>
        /// </example>
        public Count Count()
        {
            var request = new RestRequest();
            request.Resource = "/history/task/count";
            return this.Count(new QueryHelper().BuildQuery<HistoryTaskQueryModel>(this.model, request));
        }
    }
}
