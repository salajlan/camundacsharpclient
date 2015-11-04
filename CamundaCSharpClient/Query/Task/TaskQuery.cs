using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;

namespace CamundaCSharpClient.Query.Task
{
    public class TaskQuery : queryBase
    {
        protected camundaRestClient Client;
		protected string id { get; set; }
		protected string userId { get; set; }

        EnsureHelper ensure = null;

        public TaskQuery(camundaRestClient client) : base(client)
		{
			this.Client = client;
            this.ensure = new EnsureHelper();
		}

        public TaskQuery Id(string id)
		{
			this.id = id;
			return this;
		}

        public TaskQuery UserId(string userId)
		{
			this.userId = userId;
			return this;
		}

        /// <summary>Claim a task for a specific user.
        /// Note: The difference with set a assignee is that here a check is performed to see if the task already has a user assigned to it.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk1 = camundaCl.Task().Id("37ccd7fe-78c5-11e5-beb3-40a8f0a54b22").UserId("salajlan").Claim();
        ///</code>
        ///</example>
		public noContentStatus Claim()
		{
            this.ensure.ensureNotNull("Id", this.id);
            this.ensure.ensureNotNull("userId", this.userId);

			var request = new RestRequest ();
            request.Resource = "/task/" + this.id + "/claim";
            request.Method = Method.POST;
			object obj = new {this.userId};
			string output = JsonConvert.SerializeObject(obj);
			request.AddParameter("application/json", output, ParameterType.RequestBody);
			var resp = Client.Execute(request);
			return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
		}
        /// <summary> Delegate a task to another user.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk7 = camundaCl.Task().Id("c4d3d6e8-78b1-11e5-a68d-40a8f0a54b22").UserId("salajlan").Delegate();
        ///</code>
        ///</example>
        public noContentStatus Delegate()
        {
            this.ensure.ensureNotNull("Id", this.id);
            this.ensure.ensureNotNull("userId", this.userId);

            var request = new RestRequest();
            request.Resource = "/task/" + this.id + "/delegate";
            request.Method = Method.POST;
            object obj = new { this.userId };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Resets a task's assignee. If successful, the task is not assigned to a user.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk5 = camundaCl.Task().Id("37ccd7fe-78c5-11e5-beb3-40a8f0a54b22").UnClaim();           
        ///</code>
        ///</example>
        public noContentStatus UnClaim()
        {
            this.ensure.ensureNotNull("Id", this.id);

            var request = new RestRequest();
            request.Resource = "/task/" + this.id + "/unclaim";
            request.Method = Method.POST;
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Complete a task and update process variables.
        /// </summary>
        /// <param name="variables"></param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var obj = new { amount = new invoice.Amount() { value = "resolve" } };
        /// var tsk6 = camundaCl.Task().Id("ebb5bc85-789e-11e5-ac86-40a8f0a54b22").Complete(obj);
        ///</code>
        ///</example>
        public noContentStatus Complete(object variables)
        {
            this.ensure.ensureNotNull("Id", this.id);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "/task/" + id + "/complete";
            object obj = new { variables };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Resolve a task and update execution variables.
        /// </summary>
        /// <param name="variables"></param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var obj = new { amount = new invoice.Amount() { value = "resolve" } };
        /// var tsk9 = camundaCl.Task().Id("c4d3d6e8-78b1-11e5-a68d-40a8f0a54b22").Resolve(obj);
        ///</code>
        ///</example>
        public noContentStatus Resolve(object variables)
        {
            this.ensure.ensureNotNull("Id", this.id);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "/task/" + id + "/resolve";
            object obj = new { variables };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary>Change the assignee of a task to a specific user.
        /// Note: The difference with claim a task is that this method does not check if the task already has a user assigned to it.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk2 = camundaCl.Task().Id("37ccd7fe-78c5-11e5-beb3-40a8f0a54b22").UserId("salajlan").Assignee();
        ///</code>
        ///</example>
        public noContentStatus Assignee()
        {
            this.ensure.ensureNotNull("Id", this.id);
            this.ensure.ensureNotNull("userId", this.userId);

            var request = new RestRequest();
            request.Resource = "/task/" + this.id + "/assignee";
            request.Method = Method.POST;
            object obj = new { this.userId };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Gets the comments for a task. or Retrieves a single task comment by task id and comment id.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk12 = camundaCl.Task().Id("a3d0eeb5-78c4-11e5-beb3-40a8f0a54b22").Comment();
        ///</code>
        ///</example>
        public List<taskComment> Comment()
        {
            this.ensure.ensureNotNull("Id", this.id);
            var request = new RestRequest();
            request.Resource = "/task/" + this.id + "/comment";           
            return Client.Execute<List<taskComment>>(request);
        }
        /// <summary> Retrieves a single task comment by task id and comment id.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk10 = camundaCl.Task().Id("a3d0eeb5-78c4-11e5-beb3-40a8f0a54b22").Comment("d7a2ea89-7cae-11e5-beb3-40a8f0a54b22");
        ///</code>
        ///</example>
        public taskComment Comment(string commentId)
        {
            this.ensure.ensureNotNull("Id", this.id);
            this.ensure.ensureNotNull("ComemntId", commentId);
            var request = new RestRequest();
            request.Resource = "/task/" + this.id + "/comment/" + commentId;
            return Client.Execute<taskComment>(request);
        }
        /// <summary> Create a comment for a task.
        /// </summary>
        /// <param name="comment"> comment to be create</param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk11 = camundaCl.Task().Id("a3d0eeb5-78c4-11e5-beb3-40a8f0a54b22").Create("test Comment");
        ///</code>
        ///</example>
        public taskComment Create(string comment)
        {
            this.ensure.ensureNotNull("Id", this.id);
            this.ensure.ensureNotNull("commentMessage", comment);

            var request = new RestRequest();
            request.Resource = "/task/" + this.id + "/comment/create";
            request.Method = Method.POST;
            object obj = new { message = comment };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            return Client.Execute<taskComment>(request);
        }
        /// <summary> Query for tasks that fulfill a given filter.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk3 = camundaCl.Task().Get().ProcessInstanceId("37ccd7f9-78c5-11e5-beb3-40a8f0a54b22").list();
        ///</code>
        ///</example>
        public GetTaskQuery Get()
        {
            return new GetTaskQuery(this.Client);
        }
        /// <summary> Retrieves a single task
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var tsk13 = camundaCl.Task().Id("37ccd7fe-78c5-11e5-beb3-40a8f0a54b22").singleResult();
        ///</code>
        ///</example>
        public task singleResult()
        {
            this.ensure.ensureNotNull("Id", this.id);
            var request = new RestRequest();
            request.Resource = "/task/" + this.id;
            return singleResult<task>(request);
        }
    }
}
