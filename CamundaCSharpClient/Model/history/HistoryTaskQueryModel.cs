using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class HistoryTaskQueryModel
    {
        public enum SortByValue
        {
            taskId,
            activityInstanceID,
            processDefinitionId,
            processInstanceId,
            executionId,
            duration,
            endTime,
            startTime,
            taskName,
            taskDescription,
            assignee,
            owner,
            dueDate,
            followUpDate,
            deleteReason, 
            taskDefinitionKey, 
            priority, 
            caseDefinitionId, 
            caseInstanceId, 
            caseExecutionId
        }

        public string taskId { get; set; }

        public string taskParentTaskId { get; set; }

        public string processInstanceId { get; set; }

        public string executionId { get; set; }

        public string processDefinitionId { get; set; }

        public string processDefinitionKey { get; set; }

        public string processDefinitionName { get; set; }

        public string caseInstanceId { get; set; }

        public string caseExecutionId { get; set; }

        public string caseDefinitionId { get; set; }

        public string caseDefinitionKey { get; set; }

        public string caseDefinitionName { get; set; }

        public string activityInstanceIdIn { get; set; }

        public string taskName { get; set; }

        public string taskNameLike { get; set; }

        public string taskDescription { get; set; }

        public string taskDescriptionLike { get; set; }

        public string taskDefinitionKey { get; set; }

        public string taskDeleteReasonLike { get; set; }

        public string taskDeleteReason { get; set; }

        public string taskAssignee { get; set; }

        public string taskAssigneeLike { get; set; }

        public string taskOwner { get; set; }

        public string taskOwnerLike { get; set; }

        public string taskPriority { get; set; }

        public string finished { get; set; }

        public string unfinished { get; set; }

        public string processFinished { get; set; }

        public string processUnfinished { get; set; }

        public string taskDueDate { get; set; }

        public string taskDueDateBefore { get; set; }

        public string taskDueDateAfter { get; set; }

        public string taskFollowUpDate { get; set; }

        public string taskFollowUpDateBefore { get; set; }

        public string taskFollowUpDateAfter { get; set; }

        public string taskVariables { get; set; }

        public string processVariables { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }

        public int? firstResult { get; set; }

        public int? maxResults { get; set; }
    }
}
