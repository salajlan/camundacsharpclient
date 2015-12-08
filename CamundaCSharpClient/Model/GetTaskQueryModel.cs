using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class GetTaskQueryModel
    {
        public string processInstanceId { get; set; }

        public string processInstanceBusinessKey { get; set; }

        public string processInstanceBusinessKeyIn { get; set; }

        public string processInstanceBusinessKeyLike { get; set; }

        public string processDefinitionKey { get; set; }

        public string processDefinitionId { get; set; }

        public string processDefinitionKeyIn { get; set; }

        public string processDefinitionName { get; set; }

        public string processDefinitionNameLike { get; set; }

        public string executionId { get; set; }

        public string caseInstanceId { get; set; }

        public string caseDefinitionName { get; set; }

        public string caseDefinitionNameLike { get; set; }

        public string caseExecutionId { get; set; }

        public string activityInstanceIdIn { get; set; }

        public string assignee { get; set; }

        public string includeAssignedTasks { get; set; }

        public string involvedUser { get; set; }

        public string involvedUserExpression { get; set; }

        public string unassigned { get; set; }

        public string taskDefinitionKey { get; set; }

        public string descriptionLike { get; set; }

        public int? priority { get; set; }

        public int? maxPriority { get; set; }

        public int? minPriority { get; set; }

        public string dueDate { get; set; }

        public string dueDateExpression { get; set; }

        public string followUpDateExpression { get; set; }

        public string followUpAfter { get; set; }

        public string followUpAfterExpression { get; set; }

        public string followUpBefore { get; set; }

        public string followUpBeforeExpression { get; set; }

        public string followUpBeforeOrNotExistent { get; set; }

        public string followUpBeforeOrNotExistentExpression { get; set; }

        public string createdOn { get; set; }

        public string createdBeforeExpression { get; set; }

        public string delegationState { get; set; }

        public string candidateGroups { get; set; }

        public string candidateGroupsExpression { get; set; }

        public string active { get; set; }

        public string suspended { get; set; }

        public string taskVariables { get; set; }

        public string processVariables { get; set; }

        public string caseInstanceVariables { get; set; }

        public string parentTaskId { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }

        public int? firstResult { get; set; }

        public int? maxResults { get; set; }

        public string assigneeExpression { get; set; }

        public string assigneeLike { get; set; }

        public string assigneeLikeExpression { get; set; }

        public string owner { get; set; }

        public string ownerExpression { get; set; }

        public string taskDefinitionKeyIn { get; set; }

        public string taskDefinitionKeyLike { get; set; }

        public string name { get; set; }

        public string nameLike { get; set; }

        public string description { get; set; }

        public string createdOnExpression { get; set; }

        public string createdBefore { get; set; }

        public string createdAfterExpression { get; set; }

        public string createdAfter { get; set; }

        public string followUpDate { get; set; }

        public string dueBeforeExpression { get; set; }

        public string dueBefore { get; set; }

        public string dueAfterExpression { get; set; }

        public string dueAfter { get; set; }

        public string candidateUserExpression { get; set; }

        public string candidateUser { get; set; }

        public string candidateGroupExpression { get; set; }

        public string candidateGroup { get; set; }

        public string caseDefinitionKey { get; set; }

        public string caseDefinitionId { get; set; }

        public string caseInstanceBusinessKeyLike { get; set; }

        public string caseInstanceBusinessKey { get; set; }
    }
}
