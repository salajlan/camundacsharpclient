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
        /// Retrieve single processDefinition data by id or key.
        /// If there is no parameter it will retrieve all processDefinitions available.
        /// ex : getProcessDefinition(key:"invoice");
        /// GET /process-definition/key/{key} (returns the latest version of process definition)
        /// </summary>
        /// <param name="id">The id of the processDefinition to retrieve</param>
        /// <param name="key">The key (the id in the BPMN 2.0 XML. Exact match.) of the processDefinition to retrieve</param>       

        public processDefinition getProcessDefinition(string id = null, string key = null)
        {
            var request = new RestRequest();
            if (id != null) 
                request.Resource = "/process-definition/"+ id;
            else
                request.Resource = "/process-definition/key/"+ key;

            return Execute<processDefinition>(request);
        }

        /// <summary>
        /// Retrieve the processDefinitions data by different filter parameters.
        /// If there is no parameter it will retrieve all processDefinitions available.
        /// ex : getProcessDefinitions(active: true,version:1,keyLike:"inv%");
        /// </summary>
        /// <param name="name">Filter by process definition name.</param>
        /// <param name="nameLike">Filter by process definition names that the parameter is a substring of.</param>
        /// <param name="deploymentId">Filter by the deployment the id belongs to.</param>
        /// <param name="key">Filter by process definition key, i.e. the id in the BPMN 2.0 XML. Exact match</param>
        /// <param name="keyLike">Filter by process definition keys that the parameter is a substring of.</param>
        /// <param name="category">Filter by process definition category. Exact match.</param>
        /// <param name="categoryLike">Filter by process definition categories that the parameter is a substring of.</param>
        /// <param name="version">Filter by process definition version.</param>
        /// <param name="latestVersion">Only include those process definitions that are latest versions. Value may only be true, as false is the default behavior.</param>
        /// <param name="resourceName">Filter by the name of the process definition resource. Exact match.</param>
        /// <param name="resourceNameLike">Filter by names of those process definition resources that the parameter is a substring of.</param>
        /// <param name="startableBy">Filter by a user name who is allowed to start the process.</param>
        /// <param name="active">Only include active process definitions. Value may only be true, as false is the default behavior.</param>
        /// <param name="suspended">Only include suspended process definitions. Value may only be true, as false is the default behavior.</param>
        /// <param name="incidentId">Filter by the incident id.r</param>
        /// <param name="incidentType">Filter by the incident type.</param>
        /// <param name="incidentMessage">Filter by the incident message. Exact match.</param>
        /// <param name="incidentMessageLike">Filter by the incident message that the parameter is a substring of.</param>
        /// <param name="maxResults">Pagination of results. Specifies the maximum number of results to return. Will return less results if there are no more results left.</param>
        /// <param name="firstResult">Pagination of results. Specifies the index of the first result to return.</param>
        /// <param name="sortBy">Sort the results lexicographically by a given criterion. Valid values are category, key, id, name, version and deploymentId. Must be used in conjunction with the sortOrder parameter.</param>
        /// <param name="sortOrder">Sort the results in a given order. Values may be asc for ascending order or desc for descending order. Must be used in conjunction with the sortBy parameter.</param>

        public List<processDefinition> getProcessDefinitions(string key = null, string name = null, string nameLike = null, string deploymentId = null, string keyLike = null, string category = null, string categoryLike = null, int? version = null, bool latestVersion = false, string resourceName = null, string resourceNameLike = null, string startableBy = null, bool active = false, bool suspended = false, string incidentId = null, string incidentType = null, string incidentMessage = null, string incidentMessageLike = null, int? maxResults = null, int? firstResult = null, string sortBy = null, string sortOrder = null)
        {
            var request = new RestRequest();
            string processDefinitionCondition = null;

            if (name != null) processDefinitionCondition += "name=" + name + "&";
            if (nameLike != null) processDefinitionCondition += "nameLike=" + nameLike + "&";
            if (deploymentId != null) processDefinitionCondition += "deploymentId=" + deploymentId + "&";
            if (key != null) processDefinitionCondition += "key=" + key + "&";
            if (keyLike != null) processDefinitionCondition += "keyLike=" + keyLike + "&";
            if (category != null) processDefinitionCondition = "category=" + category + "&";
            if (categoryLike != null) processDefinitionCondition += "categoryLike=" + categoryLike + "&";
            if (version != null) processDefinitionCondition += "version=" + version + "&";
            if (latestVersion != false) processDefinitionCondition += "latestVersion=" + latestVersion.ToString().ToLower() + "&";
            if (resourceName != null) processDefinitionCondition += "resourceName=" + resourceName + "&";
            if (resourceNameLike != null) processDefinitionCondition += "resourceNameLike=" + resourceNameLike + "&";
            if (startableBy != null) processDefinitionCondition = "startableBy=" + startableBy + "&";
            if (active != false) processDefinitionCondition += "active=" + active.ToString().ToLower() + "&";
            if (suspended != false) processDefinitionCondition += "suspended=" + suspended.ToString().ToLower() + "&";
            if (incidentId != null) processDefinitionCondition += "incidentId=" + incidentId + "&";
            if (incidentType != null) processDefinitionCondition += "incidentType=" + incidentType + "&";
            if (incidentMessage != null) processDefinitionCondition += "incidentMessage=" + incidentMessage + "&";
            if (incidentMessageLike != null) processDefinitionCondition += "incidentMessageLike=" + incidentMessageLike + "&";
            if (maxResults != null) processDefinitionCondition = "maxResults=" + maxResults + "&";
            if (firstResult != null) processDefinitionCondition += "firstResult=" + firstResult + "&";
            if (sortBy != null && sortOrder != null) processDefinitionCondition += "sortBy=" + sortBy + "&sortOrder=" + sortOrder + "&";

            request.Resource = "/process-definition?" + processDefinitionCondition;

            return Execute<List<processDefinition>>(request);
        }

        /// <summary>
        /// Instantiates a given process definition. Process variables and business key may be supplied in the request body.
        /// ex : var start = camundaCl.startProcessInstance<invoice.CommunicationRootObject>(variables: d, businessKey: "testBusinessKey", key: "invoice");
        /// </summary>
        /// <param name="id">The id of the process definition to be retrieved.</param>
        /// <param name="key">The key of the process definition (the latest version thereof) to be retrieved.</param> 
        /// <param name="variables">A JSON object containing the variables the process is to be initialized with. Each key corresponds to a variable name and each value to a variable value. A variable value is a JSON object with the following properties:
        ///             value 	The variable's value. For variables of type Object, the serialized value has to be submitted as a String value.
        ///             type 	The value type of the variable.
        ///             valueInfo 	A JSON object containing additional, value-type-dependent properties.
        ///                         For serialized variables of type Object, the following properties can be provided:
        ///                              objectTypeName: A string representation of the object's type name.
        ///                              serializationDataFormat: The serialization format used to store the variable.

        /// </param>
        /// <param name="businessKey">The business key the process instance is to be initialized with. The business key uniquely identifies the process instance in the context of the given process definition.</param>
        /// <param name="caseInstanceId">The case instance id the process instance is to be initialized with.</param>        

        public processInstance startProcessInstance<T>(T variables, string businessKey = null, string caseInstanceId = null, string id = null, string key = null)
        {
            var request = new RestRequest();
            if (id != null)
                request.Resource = "/process-definition/" + id + "/start";
            else
                request.Resource = "/process-definition/key/" + key + "/start";

            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
            object obj = new { variables, businessKey , caseInstanceId };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            

            return Execute<processInstance>(request);
        }
    }
}
