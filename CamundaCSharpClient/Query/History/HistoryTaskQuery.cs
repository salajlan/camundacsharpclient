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
        public HistoryTaskQuery(CamundaRestClient client)
            : base(client)
        {
        }

        protected string taskId { get; set; }

        protected string taskParentTaskId { get; set; }

        protected string processInstanceId { get; set; }

        protected string executionId { get; set; }

        protected string processDefinitionId { get; set; }

        protected string processDefinitionKey { get; set; }

        protected string processDefinitionName { get; set; }

        protected string caseInstanceId { get; set; }

        protected string caseExecutionId { get; set; }

        protected string caseDefinitionId { get; set; }

        protected string caseDefinitionKey { get; set; }

        protected string caseDefinitionName { get; set; }

        protected string activityInstanceIdIn { get; set; }

        protected string taskName { get; set; }

        protected string taskNameLike { get; set; }

        protected string taskDescription { get; set; }

        protected string taskDescriptionLike { get; set; }

        protected string taskDefinitionKey { get; set; }

        protected string taskDeleteReasonLike { get; set; }

        protected string taskDeleteReason { get; set; }

        protected string taskAssignee { get; set; }

        protected string taskAssigneeLike { get; set; }

        protected string taskOwner { get; set; }

        protected string taskOwnerLike { get; set; }

        protected string taskPriority { get; set; }

        protected string finished { get; set; }

        protected string unfinished { get; set; }

        protected string processFinished { get; set; }

        protected string processUnfinished { get; set; }

        protected string taskDueDate { get; set; }

        protected string taskDueDateBefore { get; set; }

        protected string taskDueDateAfter { get; set; }

        protected string taskFollowUpDate { get; set; }

        protected string taskFollowUpDateBefore { get; set; }

        protected string taskFollowUpDateAfter { get; set; }

        protected string taskVariables { get; set; }

        protected string processVariables { get; set; }

        protected string sortBy { get; set; }

        protected string sortOrder { get; set; }

        protected int? firstResult { get; set; }

        protected int? maxResults { get; set; }

        public HistoryTaskQuery TaskId(string taskId)
        {
            this.taskId = taskId;
            return this;
        }

        public HistoryTaskQuery TaskParentTaskId(string taskParentTaskId)
        {
            this.taskParentTaskId = taskParentTaskId;
            return this;
        }

        public HistoryTaskQuery ProcessInstanceId(string processInstanceId)
        {
            this.processInstanceId = processInstanceId;
            return this;
        }

        public HistoryTaskQuery ExecutionId(string executionId)
        {
            this.executionId = executionId;
            return this;
        }

        public HistoryTaskQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.processDefinitionId = processDefinitionId;
            return this;
        }

        public HistoryTaskQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.processDefinitionKey = processDefinitionKey;
            return this;
        }

        public HistoryTaskQuery ProcessDefinitionName(string processDefinitionName)
        {
            this.processDefinitionName = processDefinitionName;
            return this;
        }

        public HistoryTaskQuery CaseInstanceId(string caseInstanceId)
        {
            this.caseInstanceId = caseInstanceId;
            return this;
        }

        public HistoryTaskQuery CaseExecutionId(string caseExecutionId)
        {
            this.caseExecutionId = caseExecutionId;
            return this;
        }

        public HistoryTaskQuery CaseDefinitionId(string caseDefinitionId)
        {
            this.caseDefinitionId = caseDefinitionId;
            return this;
        }

        public HistoryTaskQuery CaseDefinitionKey(string caseDefinitionKey)
        {
            this.caseDefinitionKey = caseDefinitionKey;
            return this;
        }

        public HistoryTaskQuery CaseDefinitionName(string caseDefinitionName)
        {
            this.caseDefinitionName = caseDefinitionName;
            return this;
        }

        public HistoryTaskQuery ActivityInstanceIdIn(List<string> activityInstanceIdIn)
        {
            string activityInstanceIdInExtract = null;  
            foreach (var item in activityInstanceIdIn)
            {
                activityInstanceIdInExtract += item + ",";
            }

            this.activityInstanceIdIn = activityInstanceIdInExtract;
            return this;
        }

        public HistoryTaskQuery TaskName(string taskName)
        {
            this.taskName = taskName;
            return this;
        }

        public HistoryTaskQuery TaskNameLike(string taskNameLike)
        {
            this.taskNameLike = taskNameLike;
            return this;
        }

        public HistoryTaskQuery TaskDescription(string taskDescription)
        {
            this.taskDescription = taskDescription;
            return this;
        }

        public HistoryTaskQuery TaskDescriptionLike(string taskDescriptionLike)
        {
            this.taskDescriptionLike = taskDescriptionLike;
            return this;
        }

        public HistoryTaskQuery TaskDefinitionKey(string taskDefinitionKey)
        {
            this.taskDefinitionKey = taskDefinitionKey;
            return this;
        }

        public HistoryTaskQuery TaskDeleteReason(string taskDeleteReason)
        {
            this.taskDeleteReason = taskDeleteReason;
            return this;
        }

        public HistoryTaskQuery TaskDeleteReasonLike(string taskDeleteReasonLike)
        {
            this.taskDeleteReasonLike = taskDeleteReasonLike;
            return this;
        }

        public HistoryTaskQuery TaskAssignee(string taskAssignee)
        {
            this.taskAssignee = taskAssignee;
            return this;
        }

        public HistoryTaskQuery TaskAssigneeLike(string taskAssigneeLike)
        {
            this.taskAssigneeLike = taskAssigneeLike;
            return this;
        }

        public HistoryTaskQuery TaskOwner(string taskOwner)
        {
            this.taskOwner = taskOwner;
            return this;
        }

        public HistoryTaskQuery TaskOwnerLike(string taskOwnerLike)
        {
            this.taskOwnerLike = taskOwnerLike;
            return this;
        }

        public HistoryTaskQuery TaskPriority(string taskPriority)
        {
            this.taskPriority = taskPriority;
            return this;
        }

        public HistoryTaskQuery Finished(bool finished)
        {
            this.finished = finished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery Unfinished(bool unfinished)
        {
            this.unfinished = unfinished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery ProcessFinished(bool processFinished)
        {
            this.processFinished = processFinished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery ProcessUnfinished(bool processUnfinished)
        {
            this.processUnfinished = processUnfinished.ToString().ToLower();
            return this;
        }

        public HistoryTaskQuery TaskDueDate(DateTime taskDueDate)
        {
            this.taskDueDate = taskDueDate.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskDueDateBefore(DateTime taskDueDateBefore)
        {
            this.taskDueDateBefore = taskDueDateBefore.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskDueDateAfter(DateTime taskDueDateAfter)
        {
            this.taskDueDateAfter = taskDueDateAfter.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskFollowUpDate(DateTime taskFollowUpDate)
        {
            this.taskFollowUpDate = taskFollowUpDate.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskFollowUpDateBefore(DateTime taskFollowUpDateBefore)
        {
            this.taskFollowUpDateBefore = taskFollowUpDateBefore.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskFollowUpDateAfter(DateTime taskFollowUpDateAfter)
        {
            this.taskFollowUpDateAfter = taskFollowUpDateAfter.ToString("s");
            return this;
        }

        public HistoryTaskQuery TaskVariables(string taskVariables)
        {
            this.taskVariables = taskVariables;
            return this;
        }

        public HistoryTaskQuery ProcessVariables(string processVariables)
        {
            this.processVariables = processVariables;
            return this;
        }

        public HistoryTaskQuery SortByAndSortOrder(string sortBy, string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }

        public HistoryTaskQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }

        public HistoryTaskQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
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
        public List<HistoryTask> List()
        {
            var request = new RestRequest();
            request.Resource = "/history/task";
            return this.List<HistoryTask>(new QueryHelper().BuildQuery<HistoryTaskQuery>(this, request));
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
            return this.Count(new QueryHelper().BuildQuery<HistoryTaskQuery>(this, request));
        }
    }
}
