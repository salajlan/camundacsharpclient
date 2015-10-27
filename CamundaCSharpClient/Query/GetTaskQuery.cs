using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;
using RestSharp;

namespace CamundaCSharpClient.Query
{
    public class GetTaskQuery : queryBase
    {
        protected string processInstanceId { get; set; }
        protected string processInstanceBusinessKey { get; set; }
        protected string processInstanceBusinessKeyIn { get; set; }
        protected string processInstanceBusinessKeyLike { get; set; }
        protected string processDefinitionKey { get; set; }
        protected string processDefinitionId { get; set; }
        protected string processDefinitionKeyIn { get; set; }
        protected string processDefinitionName { get; set; }
        protected string processDefinitionNameLike { get; set; }
        protected string executionId { get; set; }
        protected string caseInstanceId { get; set; }
        protected string caseDefinitionName { get; set; }
        protected string caseDefinitionNameLike { get; set; }
        protected string caseExecutionId { get; set; }
        protected string activityInstanceIdIn { get; set; }
        protected string assignee { get; set; }
        protected string includeAssignedTasks { get; set; }
        protected string involvedUser { get; set; }
        protected string involvedUserExpression { get; set; }
        protected string unassigned { get; set; }
        protected string taskDefinitionKey { get; set; }
        protected string descriptionLike { get; set; }
        protected int? priority { get; set; }
        protected int? maxPriority { get; set; }
        protected int? minPriority { get; set; }
        protected string dueDate { get; set; }
        protected string dueDateExpression { get; set; }
        protected string followUpDateExpression { get; set; }
        protected string followUpAfter  { get; set; }
        protected string followUpAfterExpression { get; set; }
        protected string followUpBefore  { get; set; }
        protected string followUpBeforeExpression { get; set; }
        protected string followUpBeforeOrNotExistent  { get; set; }
        protected string followUpBeforeOrNotExistentExpression { get; set; }
        protected string createdOn { get; set; }
        protected string createdBeforeExpression { get; set; }
        protected string delegationState { get; set; }
        protected string candidateGroups { get; set; }
        protected string candidateGroupsExpression { get; set; }
        protected string active  { get; set; }
        protected string suspended  { get; set; }
        protected string taskVariables { get; set; }
        protected string processVariables { get; set; }
        protected string caseInstanceVariables { get; set; }
        protected string parentTaskId { get; set; }
        protected string sortBy { get; set; }
        protected string sortOrder { get; set; }
        protected int? firstResult  { get; set; }
        protected int? maxResults  { get; set; }
        protected string assigneeExpression { get; set; }
        protected string assigneeLike { get; set; }
        protected string assigneeLikeExpression { get; set; }
        protected string owner { get; set; }
        protected string ownerExpression { get; set; }
        protected string taskDefinitionKeyIn { get; set; }
        protected string taskDefinitionKeyLike { get; set; }
        protected string name { get; set; }
        protected string nameLike { get; set; }
        protected string description { get; set; }
        protected string createdOnExpression { get; set; }

        protected string createdBefore { get; set; }

        protected string createdAfterExpression { get; set; }

        protected string createdAfter { get; set; }

        protected string followUpDate { get; set; }

        protected string dueBeforeExpression { get; set; }

        protected string dueBefore { get; set; }

        protected string dueAfterExpression { get; set; }

        protected string dueAfter { get; set; }

        protected string candidateUserExpression { get; set; }

        protected string candidateUser { get; set; }

        protected string candidateGroupExpression { get; set; }

        protected string candidateGroup { get; set; }

        protected string caseDefinitionKey { get; set; }

        protected string caseDefinitionId { get; set; }

        protected string caseInstanceBusinessKeyLike { get; set; }

        protected string caseInstanceBusinessKey { get; set; }



        public GetTaskQuery(camundaRestClient client):base(client)
        { }

        public GetTaskQuery ProcessInstanceId(string ProcessInstanceId)
        {
            this.processInstanceId = ProcessInstanceId;
            return this;
        }

        public GetTaskQuery ProcessInstanceBusinessKey(string processInstanceBusinessKey)
        {
            this.processInstanceBusinessKey = processInstanceBusinessKey;
            return this;
        }
        public GetTaskQuery ProcessInstanceBusinessKeyIn(List<string> processInstanceBusinessKeyIn)
        {
            string processDefinitionKeyInExtract = null;
            foreach (var item in processDefinitionKeyIn)
                {
                    processDefinitionKeyInExtract += item + ",";
                } 
            this.processInstanceBusinessKeyIn = processDefinitionKeyInExtract;
            return this;
        }
        public GetTaskQuery ProcessInstanceBusinessKeyLike(string processInstanceBusinessKeyLike)
        {
            this.processInstanceBusinessKeyLike = processInstanceBusinessKeyLike;
            return this;
        }
        public GetTaskQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.processDefinitionId = processDefinitionId;
            return this;
        }
        public GetTaskQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.processDefinitionKey = processDefinitionKey;
            return this;
        }
        public GetTaskQuery ProcessDefinitionKeyIn(List<string> processDefinitionKeyIn )
        {
            string processInstanceBusinessKeyInExtract = null;
            foreach (var item in processInstanceBusinessKeyIn)
                {
                    processInstanceBusinessKeyInExtract += item + ",";
                }
            this.processDefinitionKeyIn = processInstanceBusinessKeyInExtract;
            return this;
        }
        public GetTaskQuery ProcessDefinitionName(string processDefinitionName)
        {
            this.processDefinitionName = processDefinitionName;
            return this;
        }
        public GetTaskQuery ProcessDefinitionNameLike(string processDefinitionNameLike)
        {
            this.processDefinitionNameLike = processDefinitionNameLike;
            return this;
        }
        public GetTaskQuery ExecutionId(string executionId)
        {
            this.executionId = executionId;
            return this;
        }
        public GetTaskQuery CaseInstanceId(string caseInstanceId)
        {
            this.caseInstanceId = caseInstanceId;
            return this;
        }
        public GetTaskQuery CaseInstanceBusinessKey(string caseInstanceBusinessKey)
        {
            this.caseInstanceBusinessKey = caseInstanceBusinessKey;
            return this;
        }
        public GetTaskQuery CaseInstanceBusinessKeyLike(string caseInstanceBusinessKeyLike)
        {
            this.caseInstanceBusinessKeyLike = caseInstanceBusinessKeyLike;
            return this;
        }
        public GetTaskQuery CaseDefinitionId(string caseDefinitionId)
        {
            this.caseDefinitionId = caseDefinitionId;
            return this;
        }
        public GetTaskQuery CaseDefinitionKey(string caseDefinitionKey)
        {
            this.caseDefinitionKey = caseDefinitionKey;
            return this;
        }
        public GetTaskQuery CaseDefinitionName(string caseDefinitionName)
        {
            this.caseDefinitionName = caseDefinitionName;
            return this;
        }
        public GetTaskQuery CaseDefinitionNameLike(string caseDefinitionNameLike)
        {
            this.caseDefinitionNameLike = caseDefinitionNameLike;
            return this;
        }
        public GetTaskQuery CaseExecutionId(string caseExecutionId)
        {
            this.caseExecutionId = caseExecutionId;
            return this;
        }
        public GetTaskQuery ActivityInstanceIdIn(List<string> activityInstanceIdIn)
        {
            string activityInstanceIdInExtract = null;
            foreach (var item in activityInstanceIdIn)
                {
                    activityInstanceIdInExtract += item + ",";
                }
            this.activityInstanceIdIn = activityInstanceIdInExtract;
            return this;
        }
        public GetTaskQuery Assignee(string assignee)
        {
            this.assignee = assignee;
            return this;
        }
        public GetTaskQuery CandidateGroup(string candidateGroup)
        {
            this.candidateGroup = candidateGroup;
            return this;
        }
        public GetTaskQuery CandidateGroupExpression(string candidateGroupExpression)
        {
            this.candidateGroupExpression = candidateGroupExpression;
            return this;
        }
        public GetTaskQuery CandidateUser(string candidateUser)
        {
            this.candidateUser = candidateUser;
            return this;
        }
        public GetTaskQuery CandidateUserExpression(string candidateUserExpression)
        {
            this.candidateUserExpression = candidateUserExpression;
            return this;
        }
        public GetTaskQuery IncludeAssignedTasks(string includeAssignedTasks)
        {
            this.includeAssignedTasks = includeAssignedTasks;
            return this;
        }
        public GetTaskQuery InvolvedUser(string involvedUser)
        {
            this.involvedUser = involvedUser;
            return this;
        }
        public GetTaskQuery InvolvedUserExpression(string involvedUserExpression)
        {
            this.involvedUserExpression = involvedUserExpression;
            return this;
        }
        public GetTaskQuery Unassigned(bool unassigned)
        {
            this.unassigned = unassigned.ToString().ToLower();
            return this;
        }
        public GetTaskQuery TaskDefinitionKey(string taskDefinitionKey)
        {
            this.taskDefinitionKey = taskDefinitionKey;
            return this;
        }
        public GetTaskQuery TaskDefinitionKeyIn(List<string> taskDefinitionKeyIn)
        {
            string taskDefinitionKeyInExtract = null;
            foreach (var item in taskDefinitionKeyIn)
                {
                    taskDefinitionKeyInExtract += item + ",";
                }
            this.taskDefinitionKeyIn = taskDefinitionKeyInExtract;
            return this;
        }
        public GetTaskQuery TaskDefinitionKeyLike(string taskDefinitionKeyLike)
        {
            this.taskDefinitionKeyLike = taskDefinitionKeyLike;
            return this;
        }
        public GetTaskQuery Name(string name)
        {
            this.name = name;
            return this;
        }
        public GetTaskQuery NameLike(string nameLike)
        {
            this.nameLike = nameLike;
            return this;
        }
        public GetTaskQuery Description(string description)
        {
            this.description = description;
            return this;
        }
        public GetTaskQuery DueAfter(DateTime dueAfter)
        {
            this.dueAfter = dueAfter.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery DueAfterExpression(string dueAfterExpression)
        {
            this.dueAfterExpression = dueAfterExpression;
            return this;
        }
        public GetTaskQuery DueBefore(DateTime dueBefore)
        {
            this.dueBefore = dueBefore.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery DueBeforeExpression(string dueBeforeExpression)
        {
            this.dueBeforeExpression = dueBeforeExpression;
            return this;
        }
        public GetTaskQuery FollowUpDate(DateTime followUpDate)
        {
            this.followUpDate = followUpDate.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery FollowUpDateExpression(string followUpDateExpression)
        {
            this.followUpDateExpression = followUpDateExpression;
            return this;
        }
        public GetTaskQuery FollowUpAfter(DateTime followUpAfter)
        {
            this.followUpAfter = followUpAfter.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery FollowUpAfterExpression(string followUpAfterExpression)
        {
            this.followUpAfterExpression = followUpAfterExpression;
            return this;
        }
        public GetTaskQuery FollowUpBefore(DateTime followUpBefore)
        {
            this.followUpBefore = followUpBefore.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery FollowUpBeforeExpression(string followUpBeforeExpression)
        {
            this.followUpBeforeExpression = followUpBeforeExpression;
            return this;
        }
        public GetTaskQuery FollowUpBeforeOrNotExistent(DateTime followUpBeforeOrNotExistent)
        {
            this.followUpBeforeOrNotExistent = followUpBeforeOrNotExistent.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery FollowUpBeforeOrNotExistentExpression(string followUpBeforeOrNotExistentExpression)
        {
            this.followUpBeforeOrNotExistentExpression = followUpBeforeOrNotExistentExpression;
            return this;
        }
        public GetTaskQuery CreatedOn(DateTime createdOn)
        {
            this.createdOn = createdOn.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery CreatedOnExpression(string createdOnExpression)
        {
            this.createdOnExpression = createdOnExpression;
            return this;
        }
        public GetTaskQuery CreatedAfter(DateTime createdAfter)
        {
            this.createdAfter = createdAfter.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery CreatedAfterExpression(string createdAfterExpression)
        {
            this.createdAfterExpression = createdAfterExpression;
            return this;
        }
        public GetTaskQuery CreatedBefore(DateTime createdBefore)
        {
            this.createdBefore = createdBefore.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }
        public GetTaskQuery CreatedBeforeExpression(string createdBeforeExpression)
        {
            this.createdBeforeExpression = createdBeforeExpression;
            return this;
        }
        public GetTaskQuery DelegationState(string delegationState)
        {
            this.delegationState = delegationState;
            return this;
        }
        public GetTaskQuery CandidateGroups(string candidateGroups)
        {
            this.candidateGroups = candidateGroups;
            return this;
        }
        public GetTaskQuery CandidateGroupsExpression(string candidateGroupsExpression)
        {
            this.candidateGroupsExpression = candidateGroupsExpression;
            return this;
        }
        public GetTaskQuery Active(bool active)
        {
            this.active = active.ToString().ToLower();
            return this;
        }
        public GetTaskQuery Suspended(bool suspended)
        {
            this.suspended = suspended.ToString().ToLower();
            return this;
        }
        public GetTaskQuery TaskVariables(string taskVariables)
        {
            this.taskVariables = taskVariables;
            return this;
        }
        public GetTaskQuery ProcessVariables(string processVariables)
        {
            this.processVariables = processVariables;
            return this;
        }
        public GetTaskQuery CaseInstanceVariables(string caseInstanceVariables)
        {
            this.caseInstanceVariables = caseInstanceVariables;
            return this;
        }
        public GetTaskQuery ParentTaskId(string parentTaskId)
        {
            this.parentTaskId = parentTaskId;
            return this;
        }
        public GetTaskQuery SortByNsortOrder(string sortBy, string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }
        public GetTaskQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }
        public GetTaskQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }

        public List<task> list()
        {
            var request = new RestRequest();
            request.Resource = "/task?" + new queryHelper().buildQuery<GetTaskQuery>(this);
            return list<task>(request);
        }
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/task/count?" + new queryHelper().buildQuery<GetTaskQuery>(this);
            return count(request);
        }
        public task singleResult()
        {
            var request = new RestRequest();
            request.Resource = "/task?" + new queryHelper().buildQuery<GetTaskQuery>(this);
            return singleResult<task>(request);
        }
        
    }
}
