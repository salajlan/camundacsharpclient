using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient;
using RestSharp;
using CamundaCSharpClient.Model;
using Newtonsoft.Json;
using CamundaCSharpClient.Helper;

namespace CamundaCSharpClient.Query
{
    public class GroupQuery : QueryBase
    {
        private EnsureHelper ensure = null;

        public GroupQuery(CamundaRestClient client)
            : base(client)
        {
            this.ensure = new EnsureHelper();
        }

        protected string nameLike { get; set; }

        protected string name { get; set; }

        protected string id { get; set; }

        protected string type { get; set; }

        protected string member { get; set; }

        protected int? maxResults { get; set; }

        protected int? firstResult { get; set; }

        protected string sortBy { get; set; }

        protected string sortOrder { get; set; }

        public GroupQuery Id(string id)
        {
            this.id = id;
            return this;
        }

        public GroupQuery NameLike(string nameLike)
        {
            this.nameLike = nameLike;
            return this;
        }

        public GroupQuery Name(string name)
        {
            this.name = name;
            return this;
        }

        public GroupQuery Type(string type)
        {
            this.type = type;
            return this;
        }

        public GroupQuery Member(string member)
        {
            this.member = member;
            return this;
        }

        public GroupQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }

        public GroupQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }

        public GroupQuery SortByAndSortOrder(string sortBy, string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }

        /// <summary> Query for a list of groups using a list of parameters.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr2 = camundaCl.group().list();
        /// </code>
        /// </example>
        public List<Group> list()
        {
            var request = new RestRequest();
            request.Resource = "/group";
            return this.List<Group>(new QueryHelper().BuildQuery<GroupQuery>(this, request));
        }

        /// <summary> Retrieves a single group.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr9 = camundaCl.group().Id("test").singleResult();
        /// </code>
        /// </example>
        public Group singleResult()
        {
            this.ensure.NotNull("GroupId", this.id);
            var request = new RestRequest();
            request.Resource = "/group/" + this.id;
            return this.SingleResult<Group>(request);
        }

        /// <summary> Deletes a group by id. or Removes a member from a group.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr4 = camundaCl.group().Id("test").Member("salajlan").delete();
        /// var gr7 = camundaCl.group().Id("test").delete();
        /// </code>
        /// </example>
        public NoContentStatus Delete()
        {
            this.ensure.NotNull("GroupId", this.id);
            var request = new RestRequest();
            if (this.member != null)
            {
                request.Resource = "/group/" + this.id + "/members/" + this.member;
            }
            else 
            { 
                request.Resource = "/group/" + this.id;
            }

            request.Method = Method.DELETE;
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? NoContentStatus.Success : NoContentStatus.Failed;
        }

        /// <summary> Create a new group.
        /// </summary>
        /// <param name="data"> a group object to be create</param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// group m = new group() { id = "testId", name = "testName", type = "testType" };
        /// var gr3 = camundaCl.group().create(m);
        /// </code>
        /// </example>
        public NoContentStatus Create(Group data)
        {
            this.ensure.NotNull("groupData", data);
            var request = new RestRequest();
            request.Resource = "/group/create";
            request.Method = Method.POST;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? NoContentStatus.Success : NoContentStatus.Failed;
        }

        /// <summary> Updates a given group.
        /// </summary>
        /// <param name="data"> a group object to be updated</param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// group m = new group() { id = "testId", name = "testName", type = "testType" };
        /// var gr8 = camundaCl.group().Id("test").update(m);
        /// </code>
        /// </example>
        public NoContentStatus Update(Group data)
        {
            this.ensure.NotNull("groupId", this.id);
            this.ensure.NotNull("groupData", data);
            var request = new RestRequest();
            request.Resource = "/group/" + this.id;
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? NoContentStatus.Success : NoContentStatus.Failed;
        }

        /// <summary> Add a member to a group.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr6 = camundaCl.group().Id("test").Member("salajlan").create();
        /// </code>
        /// </example>
        public NoContentStatus Create()
        {
            this.ensure.NotNull("groupId", this.id);
            this.ensure.NotNull("groupMemeber", this.member);
            var request = new RestRequest();
            request.Resource = "/group/" + this.id + "/members/" + this.member;
            request.Method = Method.PUT;
            var resp = Client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? NoContentStatus.Success : NoContentStatus.Failed;
        }

        /// <summary> Query for groups using a list of parameters and retrieves the count.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr5 = camundaCl.group().Member("demo").count();
        /// </code>
        /// </example>
        public Count Count()
        {
            var request = new RestRequest();
            request.Resource = "/group/count";
            return this.Count(new QueryHelper().BuildQuery<GroupQuery>(this, request));
        }
    }
}
