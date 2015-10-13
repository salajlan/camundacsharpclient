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
        /// Retrieves a single process instance according to the ProcessInstance interface in the engine.
        /// ex : getProcessInstance("4e1c2783-6ce0-11e5-8909-103a20524153")
        /// </summary>
        /// <param name="id">The id of the process instance to retrieve</param>        

        public processInstance getProcessInstance(string id)
        {
            var request = new RestRequest();
            request.Resource = "/process-instance/" + id;

            return Execute<processInstance>(request);
        }

        /// <summary>
        /// Query for process instances that fulfill given parameters. Parameters may be static as well as dynamic runtime properties of process instances.
        /// If there is no parameter it will retrieve all process instances available.
        /// ex : camundaCl.getProcessInstances(businessKey: "testBusinessKey",processInstanceIds:prcs,suspended:true);
        /// </summary>
        /// <param name="processInstanceIds">Filter by a comma-separated list of process instance ids.</param>
        /// <param name="businessKey">Filter by process instance business key.</param>
        /// <param name="caseInstanceId">Filter by case instance id.</param>
        /// <param name="processDefinitionId">Filter by the process definition the instances run on.</param>
        /// <param name="processDefinitionKey">Filter by the key of the process definition the instances run on.</param>
        /// <param name="superProcessInstance">Restrict query to all process instances that are sub process instances of the given process instance. Takes a process instance id.</param>
        /// <param name="subProcessInstance">Restrict query to all process instances that have the given process instance as a sub process instance. Takes a process instance id.</param>
        /// <param name="superCaseInstance">Restrict query to all process instances that are sub process instances of the given case instance. Takes a case instance id.</param>
        /// <param name="subCaseInstance">Restrict query to all process instances that have the given case instance as a sub case instance. Takes a case instance id.</param>
        /// <param name="active">Only include active process instances. Value may only be true, as false is the default behavior.</param>
        /// <param name="suspended">Only include suspended process instances. Value may only be true, as false is the default behavior.</param>
        /// <param name="incidentId">Filter by the incident id.</param>
        /// <param name="incidentType">Filter by the incident type.</param>
        /// <param name="incidentMessage">Filter by the incident message. Exact match.</param>
        /// <param name="incidentMessageLike">Filter by the incident message that the parameter is a substring of.</param>
        /// <param name="variables">Only include process instances that have variables with certain values. Variable filtering expressions are comma-separated and are structured as follows:
        ///                        A valid parameter value has the form key_operator_value. key is the variable name, operator is the comparison operator to be used and value the variable value.
        ///                        Note: Values are always treated as String objects on server side.
        ///
        ///                        Valid operator values are: eq - equal to; neq - not equal to; gt - greater than; gteq - greater than or equal to; lt - lower than; lteq - lower than or equal to; like.
        ///                        key and value may not contain underscore or comma characters. 
        /// </param>
        /// <param name="sortBy">Sort the results lexicographically by a given criterion. Valid values are instanceId, definitionKey and definitionId. Must be used in conjunction with the sortOrder parameter.</param>
        /// <param name="sortOrder">Sort the results in a given order. Values may be asc for ascending order or desc for descending order. Must be used in conjunction with the sortBy parameter.</param>
        /// <param name="firstResult">Pagination of results. Specifies the index of the first result to return.</param>
        /// <param name="maxResults">Pagination of results. Specifies the maximum number of results to return. Will return less results if there are no more results left.</param>

        public List<processInstance> getProcessInstances(List<string> processInstanceIds = null, string businessKey = null, string caseInstanceId = null, string processDefinitionId = null, string processDefinitionKey = null, string superProcessInstance = null, string subProcessInstance = null, string superCaseInstance = null, string subCaseInstance = null, bool active = false, bool suspended = false, string incidentId = null, string incidentType = null, string incidentMessage = null, string incidentMessageLike = null, string variables = null, string sortBy = null, string sortOrder = null, int? firstResult = null, int? maxResults = null)
        {
            var request = new RestRequest();

            string processInstanceIdsExtract = null;
            string condition = null;

            // extract from list
            if (processInstanceIds != null)
            {
                foreach (var item in processInstanceIds)
                {
                    processInstanceIdsExtract += item + ",";
                }
                
            }

            condition = "?" + (businessKey != null ? "businessKey=" + businessKey + "&" : "") + (caseInstanceId != null ? "caseInstanceId=" + caseInstanceId + "&" : "") + (processDefinitionId != null ? "processDefinitionId=" + processDefinitionId + "&" : "") + (processDefinitionKey != null ? "processDefinitionKey=" + processDefinitionKey + "&" : "") + (superProcessInstance != null ? "superProcessInstance=" + superProcessInstance + "&" : "") + (subProcessInstance != null ? "subProcessInstance=" + subProcessInstance + "&" : "") + (superCaseInstance != null ? "superCaseInstance=" + superCaseInstance + "&" : "") + (subCaseInstance != null ? "subCaseInstance=" + subCaseInstance + "&" : "") + (active != false ? "active=" + active.ToString().ToLower() + "&" : "") + (suspended != false ? "suspended=" + suspended.ToString().ToLower() + "&" : "") + (incidentId != null ? "incidentId=" + incidentId + "&" : "") + (incidentType != null ? "incidentType=" + incidentType + "&" : "") + (incidentMessage != null ? "incidentMessage=" + incidentMessage + "&" : "") + (incidentMessageLike != null ? "incidentMessageLike=" + incidentMessageLike + "&" : "") + (variables != null ? "variables=" + variables + "&" : "") + (sortOrder != null && sortBy != null ? "sortOrder=" + sortOrder + "&sortBy=" + sortBy + "&" : "") + (firstResult != null ? "firstResult=" + firstResult + "&" : "") + (maxResults != null ? "maxResults=" + maxResults + "&" : "") + (processInstanceIds != null ? "processInstanceIds=" + processInstanceIdsExtract + "&" : "");

            request.Resource = "/process-instance" + condition;

            return Execute<List<processInstance>>(request);
        }

        /// <summary>
        /// Retrieves all variables of a given process instance
        /// ex : camundaCl.getProcessInstanceVariables<invoice.CommunicationRootObject>("6cf5cc6e-6ce0-11e5-8909-103a20524153")
        /// </summary>
        /// <param name="id">The id of the process instance to retrieve the variables from.</param>        

        public T getProcessInstanceVariables<T>(string id) where T: new()
        {
            var request = new RestRequest();
            request.Resource = "/process-instance/" + id + "/variables";

            return Execute<T>(request);
        }

        /// <summary>
        /// Retrieves a variable of a given process instance.
        /// ex : camundaCl.getProcessInstanceVariable<invoice.Comment>("6cf5cc6e-6ce0-11e5-8909-103a20524153", "comment")
        ///  --- Note : you can inherits : camundaBase , to get the RestException in any variables class
        /// </summary>
        /// <param name="id">The id of the process instance to retrieve the variables from.</param>   
        /// <param name="varId">The name of the variable to get.</param>   

        public T getProcessInstanceVariable<T>(string id,string varId) where T : new()
        {
            var request = new RestRequest();
            request.Resource = "/process-instance/" + id + "/variables/"+varId;

            return Execute<T>(request);
        }

        /// <summary>
        /// Updates or deletes the variables of a process instance. Updates precede deletions. So, if a variable is updated AND deleted, the deletion overrides the update.
        /// ex : camundaCl.updateDeleteProcessInstanceVariables<invoice.CommunicationRootObject>(id: "6cf5cc6e-6ce0-11e5-8909-103a20524153", modifications: piVars);
        /// ex delete : camundaCl.updateDeleteProcessInstanceVariables<invoice.CommunicationRootObject>(id: "6cf5cc6e-6ce0-11e5-8909-103a20524153", deletions: deletion);
        /// </summary>
        /// <param name="id">The id of the process instance to set variables for</param>   
        /// <param name="modifications">A JSON object containing variable key-value pairs. Each key is a variable name and each value a JSON variable value object</param>   
        /// <param name="deletions">An array of String keys of variables to be deleted.</param>   
        public noContentStatus updateDeleteProcessInstanceVariables<T>(string id, T modifications = default(T), string[] deletions = null)
        {
            var request = new RestRequest();
            request.Resource = "/process-instance/" + id + "/variables";


            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
            object obj = new { modifications, deletions };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);

            var resp = Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }

        /// <summary>
        /// Sets a variable of a given process instance
        /// ex : camundaCl.updateDeleteProcessInstanceVariables<invoice.CommunicationRootObject>(id: "6cf5cc6e-6ce0-11e5-8909-103a20524153", modifications: piVars);
        /// ex delete : camundaCl.updateDeleteProcessInstanceVariables<invoice.CommunicationRootObject>(id: "6cf5cc6e-6ce0-11e5-8909-103a20524153", deletions: deletion);
        /// </summary>
        /// <param name="id">The id of the process instance to set the variable for.</param>   
        /// <param name="varId">The name of the variable to srt.</param>
        /// <param name="variables">A JSON object containing the variables the process is to be initialized with. Each key corresponds to a variable name and each value to a variable value. A variable value is a JSON object with the following properties:
        ///             value 	The variable's value. For variables of type Object, the serialized value has to be submitted as a String value.
        ///             type 	The value type of the variable.
        ///             valueInfo 	A JSON object containing additional, value-type-dependent properties.
        ///                         For serialized variables of type Object, the following properties can be provided:
        ///                              objectTypeName: A string representation of the object's type name.
        ///                              serializationDataFormat: The serialization format used to store the variable.

        /// </param>
        public noContentStatus putSingleProcessInstanceVariable<T>(string id, string varId, T variables)
        {
            var request = new RestRequest();
            request.Resource = "/process-instance/" + id + "/variables/"+varId;


            request.RequestFormat = DataFormat.Json;
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(variables);
            request.AddParameter("application/json", output, ParameterType.RequestBody);

            var resp = Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
    }
}
