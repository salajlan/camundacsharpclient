using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;
using RestSharp;

namespace CamundaCSharpClient.Query.Task
{
    public class GetTaskQuery : QueryBase
    {
        private GetTaskQueryModel model = new GetTaskQueryModel();

        public GetTaskQuery(CamundaRestClient client)
            : base(client)
        {
        }        
        
        public GetTaskQuery ProcessInstanceId(string processInstanceId)
        {
            this.model.processInstanceId = processInstanceId;
            return this;
        }

        public GetTaskQuery ProcessInstanceBusinessKey(string processInstanceBusinessKey)
        {
            this.model.processInstanceBusinessKey = processInstanceBusinessKey;
            return this;
        }

        public GetTaskQuery ProcessInstanceBusinessKeyIn(List<string> processInstanceBusinessKeyIn)
        {
            string processInstanceBusinessKeyInExtract = null;
            foreach (var item in processInstanceBusinessKeyIn)
                {
                    processInstanceBusinessKeyInExtract += item + ",";
                }

            this.model.processInstanceBusinessKeyIn = processInstanceBusinessKeyInExtract;
            return this;
        }

        public GetTaskQuery ProcessInstanceBusinessKeyLike(string processInstanceBusinessKeyLike)
        {
            this.model.processInstanceBusinessKeyLike = processInstanceBusinessKeyLike;
            return this;
        }

        public GetTaskQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.model.processDefinitionId = processDefinitionId;
            return this;
        }

        public GetTaskQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.model.processDefinitionKey = processDefinitionKey;
            return this;
        }

        public GetTaskQuery ProcessDefinitionKeyIn(List<string> processDefinitionKeyIn)
        {
            string processDefinitionKeyInExtract = null;
            foreach (var item in processDefinitionKeyIn)
                {
                    processDefinitionKeyInExtract += item + ",";
                }

            this.model.processDefinitionKeyIn = processDefinitionKeyInExtract;
            return this;
        }

        public GetTaskQuery ProcessDefinitionName(string processDefinitionName)
        {
            this.model.processDefinitionName = processDefinitionName;
            return this;
        }

        public GetTaskQuery ProcessDefinitionNameLike(string processDefinitionNameLike)
        {
            this.model.processDefinitionNameLike = processDefinitionNameLike;
            return this;
        }

        public GetTaskQuery ExecutionId(string executionId)
        {
            this.model.executionId = executionId;
            return this;
        }

        public GetTaskQuery CaseInstanceId(string caseInstanceId)
        {
            this.model.caseInstanceId = caseInstanceId;
            return this;
        }

        public GetTaskQuery CaseInstanceBusinessKey(string caseInstanceBusinessKey)
        {
            this.model.caseInstanceBusinessKey = caseInstanceBusinessKey;
            return this;
        }

        public GetTaskQuery CaseInstanceBusinessKeyLike(string caseInstanceBusinessKeyLike)
        {
            this.model.caseInstanceBusinessKeyLike = caseInstanceBusinessKeyLike;
            return this;
        }

        public GetTaskQuery CaseDefinitionId(string caseDefinitionId)
        {
            this.model.caseDefinitionId = caseDefinitionId;
            return this;
        }

        public GetTaskQuery CaseDefinitionKey(string caseDefinitionKey)
        {
            this.model.caseDefinitionKey = caseDefinitionKey;
            return this;
        }

        public GetTaskQuery CaseDefinitionName(string caseDefinitionName)
        {
            this.model.caseDefinitionName = caseDefinitionName;
            return this;
        }

        public GetTaskQuery CaseDefinitionNameLike(string caseDefinitionNameLike)
        {
            this.model.caseDefinitionNameLike = caseDefinitionNameLike;
            return this;
        }

        public GetTaskQuery CaseExecutionId(string caseExecutionId)
        {
            this.model.caseExecutionId = caseExecutionId;
            return this;
        }

        public GetTaskQuery ActivityInstanceIdIn(List<string> activityInstanceIdIn)
        {
            string activityInstanceIdInExtract = null;
            foreach (var item in activityInstanceIdIn)
                {
                    activityInstanceIdInExtract += item + ",";
                }

            this.model.activityInstanceIdIn = activityInstanceIdInExtract;
            return this;
        }

        public GetTaskQuery Assignee(string assignee)
        {
            this.model.assignee = assignee;
            return this;
        }

        public GetTaskQuery CandidateGroup(string candidateGroup)
        {
            this.model.candidateGroup = candidateGroup;
            return this;
        }

        public GetTaskQuery CandidateGroupExpression(string candidateGroupExpression)
        {
            this.model.candidateGroupExpression = candidateGroupExpression;
            return this;
        }

        public GetTaskQuery CandidateUser(string candidateUser)
        {
            this.model.candidateUser = candidateUser;
            return this;
        }

        public GetTaskQuery CandidateUserExpression(string candidateUserExpression)
        {
            this.model.candidateUserExpression = candidateUserExpression;
            return this;
        }

        public GetTaskQuery IncludeAssignedTasks(string includeAssignedTasks)
        {
            this.model.includeAssignedTasks = includeAssignedTasks;
            return this;
        }

        public GetTaskQuery InvolvedUser(string involvedUser)
        {
            this.model.involvedUser = involvedUser;
            return this;
        }

        public GetTaskQuery InvolvedUserExpression(string involvedUserExpression)
        {
            this.model.involvedUserExpression = involvedUserExpression;
            return this;
        }

        public GetTaskQuery Unassigned(bool unassigned)
        {
            this.model.unassigned = unassigned.ToString().ToLower();
            return this;
        }

        public GetTaskQuery TaskDefinitionKey(string taskDefinitionKey)
        {
            this.model.taskDefinitionKey = taskDefinitionKey;
            return this;
        }

        public GetTaskQuery TaskDefinitionKeyIn(List<string> taskDefinitionKeyIn)
        {
            string taskDefinitionKeyInExtract = null;
            foreach (var item in taskDefinitionKeyIn)
                {
                    taskDefinitionKeyInExtract += item + ",";
                }

            this.model.taskDefinitionKeyIn = taskDefinitionKeyInExtract;
            return this;
        }

        public GetTaskQuery TaskDefinitionKeyLike(string taskDefinitionKeyLike)
        {
            this.model.taskDefinitionKeyLike = taskDefinitionKeyLike;
            return this;
        }

        public GetTaskQuery Name(string name)
        {
            this.model.name = name;
            return this;
        }

        public GetTaskQuery NameLike(string nameLike)
        {
            this.model.nameLike = nameLike;
            return this;
        }

        public GetTaskQuery Description(string description)
        {
            this.model.description = description;
            return this;
        }

        public GetTaskQuery DueAfter(DateTime dueAfter)
        {
            this.model.dueAfter = dueAfter.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery DueAfterExpression(string dueAfterExpression)
        {
            this.model.dueAfterExpression = dueAfterExpression;
            return this;
        }

        public GetTaskQuery DueBefore(DateTime dueBefore)
        {
            this.model.dueBefore = dueBefore.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery DueBeforeExpression(string dueBeforeExpression)
        {
            this.model.dueBeforeExpression = dueBeforeExpression;
            return this;
        }

        public GetTaskQuery FollowUpDate(DateTime followUpDate)
        {
            this.model.followUpDate = followUpDate.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery FollowUpDateExpression(string followUpDateExpression)
        {
            this.model.followUpDateExpression = followUpDateExpression;
            return this;
        }

        public GetTaskQuery FollowUpAfter(DateTime followUpAfter)
        {
            this.model.followUpAfter = followUpAfter.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery FollowUpAfterExpression(string followUpAfterExpression)
        {
            this.model.followUpAfterExpression = followUpAfterExpression;
            return this;
        }

        public GetTaskQuery FollowUpBefore(DateTime followUpBefore)
        {
            this.model.followUpBefore = followUpBefore.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery FollowUpBeforeExpression(string followUpBeforeExpression)
        {
            this.model.followUpBeforeExpression = followUpBeforeExpression;
            return this;
        }

        public GetTaskQuery FollowUpBeforeOrNotExistent(DateTime followUpBeforeOrNotExistent)
        {
            this.model.followUpBeforeOrNotExistent = followUpBeforeOrNotExistent.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery FollowUpBeforeOrNotExistentExpression(string followUpBeforeOrNotExistentExpression)
        {
            this.model.followUpBeforeOrNotExistentExpression = followUpBeforeOrNotExistentExpression;
            return this;
        }

        public GetTaskQuery CreatedOn(DateTime createdOn)
        {
            this.model.createdOn = createdOn.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery CreatedOnExpression(string createdOnExpression)
        {
            this.model.createdOnExpression = createdOnExpression;
            return this;
        }

        public GetTaskQuery CreatedAfter(DateTime createdAfter)
        {
            this.model.createdAfter = createdAfter.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery CreatedAfterExpression(string createdAfterExpression)
        {
            this.model.createdAfterExpression = createdAfterExpression;
            return this;
        }

        public GetTaskQuery CreatedBefore(DateTime createdBefore)
        {
            this.model.createdBefore = createdBefore.ToString("yyyy-MM-dd'T'HH:mm:ss");
            return this;
        }

        public GetTaskQuery CreatedBeforeExpression(string createdBeforeExpression)
        {
            this.model.createdBeforeExpression = createdBeforeExpression;
            return this;
        }

        public GetTaskQuery DelegationState(string delegationState)
        {
            this.model.delegationState = delegationState;
            return this;
        }

        public GetTaskQuery CandidateGroups(string candidateGroups)
        {
            this.model.candidateGroups = candidateGroups;
            return this;
        }

        public GetTaskQuery CandidateGroupsExpression(string candidateGroupsExpression)
        {
            this.model.candidateGroupsExpression = candidateGroupsExpression;
            return this;
        }

        public GetTaskQuery Active(bool active)
        {
            this.model.active = active.ToString().ToLower();
            return this;
        }

        public GetTaskQuery Suspended(bool suspended)
        {
            this.model.suspended = suspended.ToString().ToLower();
            return this;
        }

        public GetTaskQuery TaskVariables(string taskVariables)
        {
            this.model.taskVariables = taskVariables;
            return this;
        }

        public GetTaskQuery ProcessVariables(string processVariables)
        {
            this.model.processVariables = processVariables;
            return this;
        }

        public GetTaskQuery CaseInstanceVariables(string caseInstanceVariables)
        {
            this.model.caseInstanceVariables = caseInstanceVariables;
            return this;
        }

        public GetTaskQuery ParentTaskId(string parentTaskId)
        {
            this.model.parentTaskId = parentTaskId;
            return this;
        }

        public GetTaskQuery SortByNsortOrder(string sortBy, string sortOrder)
        {
            this.model.sortBy = sortBy;
            this.model.sortOrder = sortOrder;
            return this;
        }

        public GetTaskQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public GetTaskQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }

        /// <summary> Query for tasks that fulfill a given filter
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk3 = camundaCl.Task().Get().ProcessInstanceId("37ccd7f9-78c5-11e5-beb3-40a8f0a54b22").list();
        /// </code>
        /// </example>
        public List<task> list()
        {
            var request = new RestRequest();
            request.Resource = "/task";
            return this.List<task>(new QueryHelper().BuildQuery<GetTaskQueryModel>(this.model, request));
        }

        /// <summary> Get the number of tasks that fulfill a provided filter.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk4 = camundaCl.Task().Get().Active(true).CreatedBefore(DateTime.Now).CreatedAfter(DateTime.Parse("2015-10-20")).count();
        /// </code>
        /// </example>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/task/count";
            return this.Count(new QueryHelper().BuildQuery<GetTaskQueryModel>(this.model, request));
        }        
    }
}
