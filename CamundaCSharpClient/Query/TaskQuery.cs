using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;

namespace CamundaCSharpClient.Query
{
    public class TaskQuery
    {
        protected camundaRestClient Client;
		protected string id { get; set; }
		protected string userId { get; set; }
        protected string commentId { get; set; }

        EnsureHelper ensure = null;

        public TaskQuery(camundaRestClient client)
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

        public TaskQuery CommentId(string commentId)
        {
            this.commentId = commentId;
            return this;
        }

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

        public noContentStatus UnClaim()
        {
            this.ensure.ensureNotNull("Id", this.id);

            var request = new RestRequest();
            request.Resource = "/task/" + this.id + "/unclaim";
            request.Method = Method.POST;
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
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

        public List<taskComment> Comment()
        {
            this.ensure.ensureNotNull("Id", this.id);
            var request = new RestRequest();
            if (this.commentId == null) request.Resource = "/task/" + this.id + "/comment";
            else request.Resource = "/task/" + this.id + "/comment/"+this.commentId;            
            return Client.Execute<List<taskComment>>(request);
        }

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

        public GetTaskQuery Get()
        {
            return new GetTaskQuery(this.Client);
        }
    }
}
