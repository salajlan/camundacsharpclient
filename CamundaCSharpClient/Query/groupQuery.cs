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
    public class groupQuery : queryBase
    {
        protected string nameLike { get; set; }
        protected string name { get; set; }
        protected string id { get; set; }
        protected string type { get; set; }

        protected string member { get; set; }

        protected int? maxResults { get; set; }
        protected int? firstResult { get; set; }
        protected string sortBy { get; set; }
        protected string sortOrder { get; set; }

        EnsureHelper ensure = null;

        public groupQuery(camundaRestClient client) : base(client)
        {
            this.ensure = new EnsureHelper();
        }
        public groupQuery Id(string id)
        {
            this.id = id;
            return this;
        }
        public groupQuery NameLike(string nameLike)
        {
            this.nameLike = nameLike;
            return this;
        }

        public groupQuery Name(string name)
        {
            this.name = name;
            return this;
        }

        public groupQuery Type(string type)
        {
            this.type = type;
            return this;
        }

        public groupQuery Member(string member)
        {
            this.member = member;
            return this;
        }

        public groupQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }
        public groupQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }

        public groupQuery SortByAndSortOrder(string sortBy, string sortOrder)
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
        ///</code>
        ///</example>
        public List<group> list()
        {
            var request = new RestRequest();
            request.Resource = "/group";
            var parms = new queryHelper().buildQuery<groupQuery>(this);
            foreach (var item in parms)
            {
                request.AddParameter(item);
            }
            return list<group>(request);
        }
        /// <summary> Retrieves a single group.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr9 = camundaCl.group().Id("test").singleResult();
        ///</code>
        ///</example>
        public group singleResult()
        {
            this.ensure.ensureNotNull("GroupId", this.id);
            var request = new RestRequest();
            request.Resource = "/group/" + this.id;
            return singleResult<group>(request);
        }
        /// <summary> Deletes a group by id. or Removes a member from a group.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr4 = camundaCl.group().Id("test").Member("salajlan").delete();
        /// var gr7 = camundaCl.group().Id("test").delete();
        ///</code>
        ///</example>
        public noContentStatus delete()
        {
            this.ensure.ensureNotNull("GroupId", this.id);
            var request = new RestRequest();
            if (this.member != null) request.Resource = "/group/" + this.id + "/members/" + this.member;
            else request.Resource = "/group/" + this.id;
            request.Method = Method.DELETE;
            var resp = base.client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Create a new group.
        /// </summary>
        /// <param name="data"> a group object to be create</param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// group m = new group() { id = "testId", name = "testName", type = "testType" };
        /// var gr3 = camundaCl.group().create(m);
        ///</code>
        ///</example>
        public noContentStatus create(group data)
        {
            this.ensure.ensureNotNull("groupData", data);
            var request = new RestRequest();
            request.Resource = "/group/create";
            request.Method = Method.POST;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = base.client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Updates a given group.
        /// </summary>
        /// <param name="data"> a group object to be updated</param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// group m = new group() { id = "testId", name = "testName", type = "testType" };
        /// var gr8 = camundaCl.group().Id("test").update(m);
        ///</code>
        ///</example>
        public noContentStatus update(group data)
        {
            this.ensure.ensureNotNull("groupId", this.id);
            this.ensure.ensureNotNull("groupData", data);
            var request = new RestRequest();
            request.Resource = "/group/"+this.id;
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = base.client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Add a member to a group.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr6 = camundaCl.group().Id("test").Member("salajlan").create();
        ///</code>
        ///</example>
        public noContentStatus create()
        {
            this.ensure.ensureNotNull("groupId", this.id);
            this.ensure.ensureNotNull("groupMemeber", this.member);
            var request = new RestRequest();
            request.Resource = "/group/" + this.id + "/members/" + this.member;
            request.Method = Method.PUT;
            var resp = base.client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
        /// <summary> Query for groups using a list of parameters and retrieves the count.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr5 = camundaCl.group().Member("demo").count();
        ///</code>
        ///</example>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/group/count";
            var parms = new queryHelper().buildQuery<groupQuery>(this);
            foreach (var item in parms)
            {
                request.AddParameter(item);
            }
            return count(request);
        }
    }
}
