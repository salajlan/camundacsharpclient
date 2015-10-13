using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using RestSharp;
using Newtonsoft.Json;

namespace CamundaCSharpClient
{
    public partial class camundaRestClient
    {
        /// <summary>
        /// Retrieves a single task by its id.
        /// ex : camundaCl.getTask("d458c473-6d95-11e5-8909-103a20524153");       
        /// </summary>
        /// <param name="id">The id of the task to be retrieved.</param>
        public task getTask(string id)
        {
            var request = new RestRequest();

            request.Resource = "/task/" + id;

            return Execute<task>(request);
        }

        /// <summary>
        /// Query for tasks that fulfill a given filter.
        /// ex : getTasks(createdBefore:DateTime.Now,taskDefinitionKeyIn:lsTskDef,assignee:"salajlan");
        /// </summary>
        /// <param name="processInstanceId">Restrict to tasks that belong to process instances with the given id.</param>
        /// <param name="processInstanceBusinessKey">Restrict to tasks that belong to process instances with the given business key.</param>
        /// <param name="processInstanceBusinessKeyIn">Restrict to tasks that belong to process instances with one of the give business keys. The keys need to be in a comma-separated list. </param>
        /// <param name="processInstanceBusinessKeyLike">Restrict to tasks that have a process instance business key that has the parameter value as a substring.</param>
        /// <param name="processDefinitionId">Restrict to tasks that belong to a process definition with the given id.</param>
        /// <param name="processDefinitionKeyIn">Restrict to tasks that belong to a process definition with one of the given keys. The keys need to be in a comma-separated list. </param>
        /// <param name="processDefinitionName">Restrict to tasks that belong to a process definition with the given name.</param>
        /// <param name="processDefinitionNameLike">Restrict to tasks that have a process definition name that has the parameter value as a substring.</param>
        /// <param name="executionId">Restrict to tasks that belong to an execution with the given id.</param>
        /// <param name="caseInstanceId">Restrict to tasks that belong to case instances with the given id.</param>
        /// <param name="caseInstanceBusinessKey">Restrict to tasks that belong to case instances with the given business key.</param>
        /// <param name="caseInstanceBusinessKeyLike">Restrict to tasks that have a case instance business key that has the parameter value as a substring.</param>
        /// <param name="caseDefinitionId">Restrict to tasks that belong to a case definition with the given id.</param>
        /// <param name="caseDefinitionKey">Restrict to tasks that belong to a case definition with the given key.</param>
        /// <param name="caseDefinitionName">Restrict to tasks that belong to a case definition with the given name.</param>
        /// <param name="caseDefinitionNameLike">Restrict to tasks that have a case definition name that has the parameter value as a substring.</param>
        /// <param name="caseExecutionId">Restrict to tasks that belong to a case execution with the given id.</param>
        /// <param name="activityInstanceIdIn">Only include tasks which belong to one of the passed and comma-separated activity instance ids.</param>
        /// <param name="assignee">Restrict to tasks that the given user is assigned to.</param>
        /// <param name="assigneeExpression">Restrict to tasks that the user described by the given expression is assigned to.</param>
        /// <param name="assigneeLike">Restrict to tasks that have an assignee that has the parameter value as a substring.</param>
        /// <param name="assigneeLikeExpression">Restrict to tasks that have an assignee that has the parameter value described by the given expression as a substring. </param>
        /// <param name="owner">Restrict to tasks that the given user owns.</param>
        /// <param name="ownerExpression">Restrict to tasks that the user described by the given expression owns.</param>
        /// <param name="candidateGroup">Only include tasks that are offered to the given group.</param>
        /// <param name="candidateGroupExpression">Only include tasks that are offered to the group described by the given expression.</param>
        /// <param name="candidateUser">Only include tasks that are offered to the given user.</param>
        /// <param name="candidateUserExpression">Only include tasks that are offered to the user described by the given expression.</param>
        /// <param name="includeAssignedTasks">Also include tasks that are assigned to users in candidate queries. Default is to only include tasks that are not assigned to any user if you query by candidate user or group(s). </param>
        /// <param name="involvedUser">Only include tasks that the given user is involved in. A user is involved in a task if an identity link exists between task and user (e.g. the user is the assignee).</param>
        /// <param name="involvedUserExpression">Only include tasks that the user described by the given expression is involved in. A user is involved in a task if an identity link exists between task and user (e.g., the user is the assignee).</param>
        /// <param name="unassigned">If set to true, restricts the query to all tasks that are unassigned.</param>
        /// <param name="taskDefinitionKey">Restrict to tasks that have the given key.</param>
        /// <param name="taskDefinitionKeyIn">Restrict to tasks that have one of the given keys. The keys need to be in a comma-separated list. </param>
        /// <param name="taskDefinitionKeyLike">Restrict to tasks that have a key that has the parameter value as a substring.</param>
        /// <param name="name">Restrict to tasks that have the given name.</param>
        /// <param name="nameLike">Restrict to tasks that have a name with the given parameter value as substring.</param>
        /// <param name="description">Restrict to tasks that have the given description.</param>
        /// <param name="descriptionLike">Restrict to tasks that have a description that has the parameter value as a substring.</param>
        /// <param name="priority">Restrict to tasks that have the given priority.</param>
        /// <param name="maxPriority">Restrict to tasks that have a lower or equal priority.</param>
        /// <param name="minPriority">Restrict to tasks that have a higher or equal priority.</param>
        /// <param name="dueDate">Restrict to tasks that are due on the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="dueDateExpression">Restrict to tasks that are due on the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="dueAfter">Restrict to tasks that are due after the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="dueAfterExpression">Restrict to tasks that are due after the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="dueBefore">Restrict to tasks that are due before the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="dueBeforeExpression">Restrict to tasks that are due before the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="followUpDate">Restrict to tasks that have a followUp date on the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="followUpDateExpression">Restrict to tasks that have a followUp date on the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="followUpAfter">Restrict to tasks that have a followUp date after the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="followUpAfterExpression">Restrict to tasks that have a followUp date after the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="followUpBefore">Restrict to tasks that have a followUp date before the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="followUpBeforeExpression">Restrict to tasks that have a followUp date before the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="followUpBeforeOrNotExistent">Restrict to tasks that have no followUp date or a followUp date before the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45. The typical use case is to query all "active" tasks for a user for a given date.</param>
        /// <param name="followUpBeforeOrNotExistentExpression">Restrict to tasks that have no followUp date or a followUp date before the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="createdOn"> Restrict to tasks that were created on the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45. Note: if the used database saves dates with milliseconds precision this query only will return tasks created on the given timestamp with zero milliseconds. </param>
        /// <param name="createdOnExpression">Restrict to tasks that were created on the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="createdAfter">Restrict to tasks that were created after the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="createdAfterExpression">Restrict to tasks that were created after the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="createdBefore">Restrict to tasks that were created before the given date. The date must have the format yyyy-MM-dd'T'HH:mm:ss, e.g., 2013-01-23T14:42:45.</param>
        /// <param name="createdBeforeExpression">Restrict to tasks that were created before the date described by the given expression. See the user guide for more information on available functions. The expression must evaluate to a java.util.Date or org.joda.time.DateTime object. </param>
        /// <param name="delegationState">Restrict to tasks that are in the given delegation state. Valid values are PENDING and RESOLVED.</param>
        /// <param name="candidateGroups">Restrict to tasks that are offered to any of the given candidate groups. Takes a comma-separated list of group names, so for example developers,support,sales.</param>
        /// <param name="candidateGroupsExpression">Restrict to tasks that are offered to any of the candidate groups described by the given expression. See the user guide for more information on available functions. The expression must evaluate to java.util.List of Strings. </param>
        /// <param name="active">Only include active tasks. Value may only be true, as false is the default behavior.</param>
        /// <param name="suspended">Only include suspended tasks. Value may only be true, as false is the default behavior.</param>
        /// <param name="taskVariables">Only include tasks that have variables with certain values. Variable filtering expressions are comma-separated and are structured as follows:
        ///  A valid parameter value has the form key_operator_value. key is the variable name, operator is the comparison operator to be used and value the variable value.
        /// Note: Values are always treated as String objects on server side.
        /// Valid operator values are: eq - equal to; neq - not equal to; gt - greater than; gteq - greater than or equal to; lt - lower than; lteq - lower than or equal to; like.
        /// key and value may not contain underscore or comma characters. </param>
        /// <param name="processVariables"></param>
        /// <param name="caseInstanceVariables"></param>
        /// <param name="parentTaskId">Restrict query to all tasks that are sub tasks of the given task. Takes a task id.</param>
        /// <param name="sortBy">Sort the results lexicographically by a given criterion. Valid values are instanceId, caseInstanceId, dueDate, executionId, caseExecutionId,assignee, created, description, id, name, nameCaseInsensitive and priority. Must be used in conjunction with the sortOrder parameter.</param>
        /// <param name="sortOrder">Sort the results in a given order. Values may be asc for ascending order or desc for descending order. Must be used in conjunction with the sortBy parameter.</param>
        /// <param name="firstResult">Pagination of results. Specifies the index of the first result to return.</param>
        /// <param name="maxResults">Pagination of results. Specifies the maximum number of results to return. Will return less results if there are no more results left.</param>
        public List<task> getTasks(string processInstanceId = null, string processInstanceBusinessKey = null, List<string> processInstanceBusinessKeyIn = null, string processInstanceBusinessKeyLike = null, string processDefinitionId = null, string processDefinitionKey = null, List<string> processDefinitionKeyIn = null, string processDefinitionName = null, string processDefinitionNameLike = null, string executionId = null, string caseInstanceId = null, string caseInstanceBusinessKey = null, string caseInstanceBusinessKeyLike = null, string caseDefinitionId = null, string caseDefinitionKey = null, string caseDefinitionName = null, string caseDefinitionNameLike = null, string caseExecutionId = null, List<string> activityInstanceIdIn = null, string assignee = null, string assigneeExpression = null, string assigneeLike = null, string assigneeLikeExpression = null, string owner = null, string ownerExpression = null, string candidateGroup = null, string candidateGroupExpression = null, string candidateUser = null, string candidateUserExpression = null, string includeAssignedTasks = null, string involvedUser = null, string involvedUserExpression = null, bool unassigned = false, string taskDefinitionKey = null, List<string> taskDefinitionKeyIn = null, string taskDefinitionKeyLike = null, string name = null, string nameLike = null, string description = null, string descriptionLike = null, int? priority = null, int? maxPriority = null, int? minPriority = null, DateTime? dueDate = null, string dueDateExpression = null, DateTime? dueAfter = null, string dueAfterExpression = null, DateTime? dueBefore = null, string dueBeforeExpression = null, DateTime? followUpDate = null, string followUpDateExpression = null, DateTime? followUpAfter = null, string followUpAfterExpression = null, DateTime? followUpBefore = null, string followUpBeforeExpression = null, DateTime? followUpBeforeOrNotExistent = null, string followUpBeforeOrNotExistentExpression = null, DateTime? createdOn = null, string createdOnExpression = null, DateTime? createdAfter = null, string createdAfterExpression = null, DateTime? createdBefore = null, string createdBeforeExpression = null, string delegationState = null, string candidateGroups = null, string candidateGroupsExpression = null, bool active = false, bool suspended = false, string taskVariables = null, string processVariables = null, string caseInstanceVariables = null, string parentTaskId = null, string sortBy = null, string sortOrder = null, int? firstResult = null, int? maxResults = null)
        {
            var request = new RestRequest();

            string processDefinitionKeyInExtract = null;
            string processInstanceBusinessKeyInExtract = null;
            string activityInstanceIdInExtract = null;
            string taskDefinitionKeyInExtract = null;
            if (processDefinitionKeyIn != null)
            {
                foreach (var item in processDefinitionKeyIn)
                {
                    processDefinitionKeyInExtract += item + ",";
                }                
            }
            if (processInstanceBusinessKeyIn != null)
            {
                foreach (var item in processInstanceBusinessKeyIn)
                {
                    processInstanceBusinessKeyInExtract += item + ",";
                }
            }
            if (activityInstanceIdIn != null)
            {
                foreach (var item in activityInstanceIdIn)
                {
                    activityInstanceIdInExtract += item + ",";
                }
            }
            if (taskDefinitionKeyIn != null)
            {
                foreach (var item in taskDefinitionKeyIn)
                {
                    taskDefinitionKeyInExtract += item + ",";
                }
            }

            string condition = "?" + (processInstanceId != null ? "processInstanceId=" + processInstanceId + "&" : "") + (processInstanceBusinessKey != null ? "processInstanceBusinessKey=" + processInstanceBusinessKey + "&" : "") + (processInstanceBusinessKeyInExtract != null ? "processInstanceBusinessKeyIn=" + processInstanceBusinessKeyIn + "&" : "") + (processInstanceBusinessKeyLike != null ? "processInstanceBusinessKeyLike=" + processInstanceBusinessKeyLike + "&" : "") + (processDefinitionId != null ? "processDefinitionId=" + processDefinitionId + "&" : "") + (processDefinitionKey != null ? "processDefinitionKey=" + processDefinitionKey + "&" : "") + (processDefinitionKeyInExtract != null ? "processDefinitionKeyIn=" + processDefinitionKeyInExtract + "&" : "") + (processDefinitionName != null ? "processDefinitionName=" + processDefinitionName + "&" : "") + (processDefinitionNameLike != null ? "processDefinitionNameLike=" + processDefinitionNameLike + "&" : "") + (executionId != null ? "executionId=" + executionId + "&" : "") + (caseInstanceId != null ? "caseInstanceId=" + caseInstanceId + "&" : "") + (caseInstanceBusinessKey != null ? "caseInstanceBusinessKey=" + caseInstanceBusinessKey + "&" : "") + (caseInstanceBusinessKeyLike != null ? "caseInstanceBusinessKeyLike=" + caseInstanceBusinessKeyLike + "&" : "") + (caseDefinitionId != null ? "caseDefinitionId=" + caseDefinitionId + "&" : "") + (caseDefinitionKey != null ? "caseDefinitionKey=" + caseDefinitionKey + "&" : "") + (caseDefinitionName != null ? "caseDefinitionName=" + caseDefinitionName + "&" : "") + (caseDefinitionNameLike != null ? "caseDefinitionNameLike=" + caseDefinitionNameLike + "&" : "") + (caseExecutionId != null ? "caseExecutionId=" + caseExecutionId + "&" : "") + (activityInstanceIdIn != null ? "activityInstanceIdIn=" + activityInstanceIdIn + "&" : "") + (assignee != null ? "assignee=" + assignee + "&" : "") + (assigneeExpression != null ? "assigneeExpression=" + assigneeExpression + "&" : "") + (assigneeLike != null ? "assigneeLike=" + assigneeLike + "&" : "") + (assigneeLikeExpression != null ? "assigneeLikeExpression=" + assigneeLikeExpression + "&" : "") + (owner != null ? "owner=" + owner + "&" : "") + (ownerExpression != null ? "ownerExpression=" + ownerExpression + "&" : "") + (candidateGroup != null ? "candidateGroup=" + candidateGroup + "&" : "") + (candidateGroupExpression != null ? "candidateGroupExpression=" + candidateGroupExpression + "&" : "") + (candidateUser != null ? "candidateUser=" + candidateUser + "&" : "") + (candidateUserExpression != null ? "candidateUserExpression=" + candidateUserExpression + "&" : "") + (includeAssignedTasks != null ? "includeAssignedTasks=" + includeAssignedTasks + "&" : "") + (involvedUser != null ? "involvedUser=" + involvedUser + "&" : "") + (involvedUserExpression != null ? "involvedUserExpression=" + involvedUserExpression + "&" : "") + (unassigned != false ? "unassigned=" + unassigned + "&" : "") + (taskDefinitionKey != null ? "taskDefinitionKey=" + taskDefinitionKey + "&" : "") + (taskDefinitionKeyInExtract != null ? "taskDefinitionKeyIn=" + taskDefinitionKeyInExtract + "&" : "") + (taskDefinitionKeyLike != null ? "taskDefinitionKeyLike=" + taskDefinitionKeyLike + "&" : "") + (name != null ? "name=" + name + "&" : "") + (nameLike != null ? "nameLike=" + nameLike + "&" : "") + (description != null ? "description=" + description + "&" : "") + (descriptionLike != null ? "descriptionLike=" + descriptionLike + "&" : "") + (priority != null ? "priority=" + priority + "&" : "") + (maxPriority != null ? "maxPriority=" + maxPriority + "&" : "") + (minPriority != null ? "minPriority=" + minPriority + "&" : "") + (dueDate != null ? "dueDate=" + dueDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (dueDateExpression != null ? "dueDateExpression=" + dueDateExpression + "&" : "") + (dueAfter != null ? "dueAfter=" + dueAfter.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (dueAfterExpression != null ? "dueAfterExpression=" + dueAfterExpression + "&" : "") + (dueBefore != null ? "dueBefore=" + dueBefore.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (dueBeforeExpression != null ? "dueBeforeExpression=" + dueBeforeExpression + "&" : "") + (followUpDate != null ? "followUpDate=" + followUpDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (followUpDateExpression != null ? "followUpDateExpression=" + followUpDateExpression + "&" : "") + (followUpAfter != null ? "followUpAfter=" + followUpAfter.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (followUpAfterExpression != null ? "followUpAfterExpression=" + followUpAfterExpression + "&" : "") + (followUpBefore != null ? "followUpBefore=" + followUpBefore.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (followUpBeforeExpression != null ? "followUpBeforeExpression=" + followUpBeforeExpression + "&" : "") + (followUpBeforeOrNotExistent != null ? "followUpBeforeOrNotExistent=" + followUpBeforeOrNotExistent.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (followUpBeforeOrNotExistentExpression != null ? "followUpBeforeOrNotExistentExpression=" + followUpBeforeOrNotExistentExpression + "&" : "") + (createdOn != null ? "createdOn=" + createdOn.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (createdOnExpression != null ? "createdOnExpression=" + createdOnExpression + "&" : "") + (createdAfter != null ? "createdAfter=" + createdAfter.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (createdAfterExpression != null ? "createdAfterExpression=" + createdAfterExpression + "&" : "") + (createdBefore != null ? "createdBefore=" + createdBefore.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") + "&" : "") + (createdBeforeExpression != null ? "createdBeforeExpression=" + createdBeforeExpression + "&" : "") + (delegationState != null ? "delegationState=" + delegationState + "&" : "") + (candidateGroups != null ? "candidateGroups=" + candidateGroups + "&" : "") + (candidateGroupsExpression != null ? "candidateGroupsExpression=" + candidateGroupsExpression + "&" : "") + (active != false ? "active=" + active + "&" : "") + (suspended != false ? "suspended=" + suspended + "&" : "") + (taskVariables != null ? "taskVariables=" + taskVariables + "&" : "") + (processVariables != null ? "processVariables=" + processVariables + "&" : "") + (caseInstanceVariables != null ? "caseInstanceVariables=" + caseInstanceVariables + "&" : "") + (parentTaskId != null ? "parentTaskId=" + parentTaskId + "&" : "") + (firstResult != null ? "firstResult=" + firstResult + "&" : "") + (maxResults != null ? "maxResults=" + maxResults + "&" : "") + (sortOrder != null && sortBy != null ? "sortOrder=" + sortOrder + "&sortBy=" + sortBy + "&" : "");
            
            request.Resource = "/task"+condition;

            return Execute<List<task>>(request);
        }

        /// <summary>
        /// Claim a task for a specific user.
        /// Note: The difference with set a assignee is that here a check is performed to see if the task already has a user assigned to it.
        /// ex : camundaCl.claimTask("d458c473-6d95-11e5-8909-103a20524153", "salajlan");
        /// </summary>
        /// <param name="id">The id of the task to claim.</param>
        /// <param name="userId">The id of the user that claims the task.</param>
        public noContentStatus claimTask(string id, string userId)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "/task/" + id + "/claim";
            object obj = new { userId };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;            
        }

        /// <summary>
        /// Change the assignee of a task to a specific user.
        /// Note: The difference with claim a task is that this method does not check if the task already has a user assigned to it.
        /// ex : 
        /// </summary>
        /// <param name="id">The id of the task to set the assignee for.</param>
        /// <param name="userId">The id of the user that will be the assignee of the task.</param>
        public noContentStatus assigneeTask(string id, string userId)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "/task/" + id + "/assignee";
            object obj = new { userId };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }

        /// <summary>
        /// Resets a task's assignee. If successful, the task is not assigned to a user.o see if the task already has a user assigned to it.
        /// ex : camundaCl.unClaimTask("d458c473-6d95-11e5-8909-103a20524153");
        /// </summary>
        /// <param name="id">The id of the task to unclaim.</param>
        public noContentStatus unClaimTask(string id)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "/task/" + id + "/unclaim";
            var resp = Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }

        /// <summary>
        /// Complete a task and update process variables.
        /// ex : 
        /// </summary>
        /// <param name="id">The id of the task to complete.</param>
        /// <param name="variables">A JSON object containing variable key-value pairs. Each key is a variable name and each value a JSON variable value object</param>
        public noContentStatus completeTask<T>(string id, T variables)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "/task/" + id + "/complete";
            object obj = new { variables };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
    }
}
