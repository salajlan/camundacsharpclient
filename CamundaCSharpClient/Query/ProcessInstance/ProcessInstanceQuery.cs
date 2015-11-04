using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model;
using RestSharp;
using Newtonsoft.Json;

namespace CamundaCSharpClient.Query.ProcessInstance
{
    public class ProcessInstanceQuery : queryBase
    {
        protected string id { get; set; }
        protected string varId { get; set; }
        protected string deserializeValues { get; set; }
        protected string suspended { get; set; }
        protected string processDefinitionId { get; set; }
        protected string processDefinitionKey { get; set; }
        EnsureHelper ensure = null;
        public ProcessInstanceQuery Id(string id)
        {
            this.id = id;
            return this;
        }
        public ProcessInstanceQuery VarId(string varId)
        {
            this.varId = varId ;
            return this;
        }
        public ProcessInstanceQuery DeserializeValues(bool deserializeValues)
        {
            this.deserializeValues = deserializeValues.ToString().ToLower();
            return this;
        }
        public ProcessInstanceQuery ProcessDefinitionId(string processDefinitionId)
        {
            this.processDefinitionId = processDefinitionId;
            return this;
        }
        public ProcessInstanceQuery ProcessDefinitionKey(string processDefinitionKey)
        {
            this.processDefinitionKey = processDefinitionKey;
            return this;
        }
        public ProcessInstanceQuery Suspended(bool suspended)
        {
            this.suspended = suspended.ToString().ToLower();
            return this;
        }
        public ProcessInstanceQuery(camundaRestClient client) :base(client)
        {
            ensure = new EnsureHelper();
        }
        /// <summary>
        /// Query for process instances that fulfill given parameters. Parameters may be static as well as dynamic runtime properties of process instances.
        /// If there is no parameter it will retrieve all process instances available.
        /// ex : camundaCl.getProcessInstances(businessKey: "testBusinessKey",processInstanceIds:prcs,suspended:true);
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pi1 = camundaCl.ProcessInstance().Get().BusinessKey("hi").list();
        ///</code>
        ///</example>
        public GetProcessInstanceQuery Get()
        {
            return new GetProcessInstanceQuery(client);
        }
        /// <summary>
        /// Retrieves a single process instance according to the ProcessInstance interface in the engine.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");   
        /// var pi = camundaCl.ProcessInstance().Id("a0efef43-7d51-11e5-beb3-40a8f0a54b22").SingleResult();
        ///</code>
        ///</example>
        public processInstance SingleResult()
        {
            ensure.ensureNotNull("ProcessInstanceId", this.id);
            var request = new RestRequest();
            request.Resource = "/process-instance/" + this.id;
            return singleResult<processInstance>(request);
        }
        /// <summary>Deletes a running process instance. or Deletes a variable of a given process instance.
        /// </summary>
        /// <example> Deletes a running process instance
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pi3 = camundaCl.ProcessInstance().Id("182112c8-78c1-11e5-beb3-40a8f0a54b22").Delete();
        ///</code>
        ///</example>
        /// <example> Deletes a variable of a given process instance.
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pi3 = camundaCl.ProcessInstance().Id("182112c8-78c1-11e5-beb3-40a8f0a54b22").VarId("test varriable").Delete();
        ///</code>
        ///</example>
        public noContentStatus Delete()
        {
            ensure.ensureNotNull("ProcessInstanceId", this.id);
            var request = new RestRequest();
            if (this.varId != null) request.Resource = "/process-instance/" + this.id + "/variables/" + this.varId;
            else request.Resource = "/process-instance/" + this.id;            
            request.Method = Method.DELETE;
            var resp = client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary>
        /// Retrieves a variables of a given process instance or given Variable Id
        /// </summary>
        /// <example> retrive by variables by process instance Id
        /// <code>
        /// 
        ///var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        ///var pi5 = camundaCl.ProcessInstance().Id("84b04b82-7cbc-11e5-beb3-40a8f0a54b22").Variables<invoice.InvoiceRootObject>();
        ///
        ///</code>
        ///</example>
        /// <example> retrive by variable by process instance Id and variable Id
        /// <code>
        /// 
        ///var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        ///var pi4 = camundaCl.ProcessInstance().Id("84b04b82-7cbc-11e5-beb3-40a8f0a54b22").VarId("amount").Variables<invoice.amount>();
        ///
        ///</code>
        ///</example>

        public T Variables<T>() where T : new()
        {
            ensure.ensureNotNull("ProcessInstanceId", this.id);
            var request = new RestRequest();
            if (this.varId != null) request.Resource = "/process-instance/" + this.id + "/variables/" + this.varId;
            else request.Resource = "/process-instance/" + this.id + "/variables";
            string output = JsonConvert.SerializeObject(this.deserializeValues);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            return client.Execute<T>(request);

        }
        /// <summary>
        /// Updates or deletes the variables of a process instance. Updates precede deletions. So, if a variable is updated AND deleted, the deletion overrides the update.
        /// </summary>        
        /// <param name="modifications">A JSON object containing variable key-value pairs. Each key is a variable name and each value a JSON variable value object</param>   
        /// <param name="deletions">An array of String keys of variables to be deleted.</param>
        /// <example>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var obj = new { amount = new invoice.Amount() { value = "modification" } };
        /// var pi6 = camundaCl.ProcessInstance().Id("84b04b82-7cbc-11e5-beb3-40a8f0a54b22").Variables<object>(obj, new string[] { "amount" });
        /// <code>
        ///</code>
        ///</example>
        public noContentStatus Variables<T>(T modifications, string[] deletions)
        {
            ensure.ensureNotNull("ProcessInstanceId", this.id);
            var request = new RestRequest();
            request.Resource = "/process-instance/" + this.id + "/variables";
            request.Method = Method.POST;
            object obj = new { modifications, deletions };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;

        }
        /// <summary>
        /// Sets a variable of a given process instance
        /// </summary>
        /// <param name="variables">A JSON object containing the variables the process is to be initialized with. Each key corresponds to a variable name and each value to a variable value. A variable value is a JSON object with the following properties:
        ///             value 	The variable's value. For variables of type Object, the serialized value has to be submitted as a String value.
        ///             type 	The value type of the variable.
        ///             valueInfo 	A JSON object containing additional, value-type-dependent properties.
        ///                         For serialized variables of type Object, the following properties can be provided:
        ///                              objectTypeName: A string representation of the object's type name.
        ///                              serializationDataFormat: The serialization format used to store the variable.

        /// </param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pi7 = camundaCl.ProcessInstance().Id("84b04b82-7cbc-11e5-beb3-40a8f0a54b22").VarId("DeptHead").Variables<invoice.DeptHead>(new invoice.DeptHead() { value = "salajlan" });
        ///</code>
        ///</example>
        public noContentStatus Variables<T>(T variable)
        {
            ensure.ensureNotNull("ProcessInstanceId", this.id);
            ensure.ensureNotNull("variableData", variable);
            ensure.ensureNotNull("varId", this.varId);
            var request = new RestRequest();
            request.Resource = "/process-instance/" + this.id + "/variables/"+this.varId;
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(variable);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;

        }
        /// <summary>
        /// Activate or suspend a given process instance.
        /// Activate or suspend process instances with the given process definition id.
        /// Activate or suspend process instances with the given process definition key.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pi9 = camundaCl.ProcessInstance().Id("a8a4755f-78b2-11e5-878f-40a8f0a54b22").Suspended(false).Suspend();
        /// var pi10 = camundaCl.ProcessInstance().ProcessDefinitionKey("invoice").Suspended(false).Suspend();
        /// var pi11 = camundaCl.ProcessInstance().ProcessDefinitionId("invoice:1:54302a7a-7736-11e5-bc04-40a8f0a54b22").Suspended(true).Suspend();
        ///</code>
        ///</example>
        /// <returns>noContentStatus</returns>
        public noContentStatus Suspend()
        {
            this.ensure.ensureNotNull("Suspended", this.suspended);
            object obj;
            var request = new RestRequest();
            request.Resource = "/process-instance/suspended";
            if (this.id != null)
            {
                request.Resource = "/process-instance/" + this.id + "/suspended";
                obj = new { this.suspended };
            }
            else if (this.processDefinitionId == null)
            {
                this.ensure.ensureNotNull("processDefinitionKey", this.processDefinitionKey);
                obj = new { this.processDefinitionKey, this.suspended };
            }
            else obj = new { this.processDefinitionId, this.suspended };

            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary>
        /// Retrieves an Activity Instance (Tree) for a given process instance.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pi12 = camundaCl.ProcessInstance().Id("14cc53f0-8067-11e5-ac78-40a8f0a54b22").ActivityInstance();
        ///</code>
        ///</example>
        /// <returns>activityInstance</returns>
        public activityInstance ActivityInstance()
        {
            ensure.ensureNotNull("processInstanceId", this.id);
            var request = new RestRequest();
            request.Resource = "/process-instance/" + this.id + "/activity-instances";
            return client.Execute<activityInstance>(request);
        }
    }
}
