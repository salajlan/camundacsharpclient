using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient;
using RestSharp;
using CamundaCSharpClient.Model;
using Newtonsoft.Json;
using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model.Group;

namespace CamundaCSharpClient.Query
{
    public class GroupQuery : QueryBase
    {
        private EnsureHelper ensure = null;
        private GroupQueryModel model = new GroupQueryModel();

        public GroupQuery(CamundaRestClient client)
            : base(client)
        {
            this.ensure = new EnsureHelper();
        }        

        public GroupQuery Id(string id)
        {
            this.model.id = id;
            return this;
        }

        public GroupQuery NameLike(string nameLike)
        {
            this.model.nameLike = nameLike;
            return this;
        }

        public GroupQuery Name(string name)
        {
            this.model.name = name;
            return this;
        }

        public GroupQuery Type(string type)
        {
            this.model.type = type;
            return this;
        }

        public GroupQuery Member(string member)
        {
            this.model.member = member;
            return this;
        }

        public GroupQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }

        public GroupQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public GroupQuery SortByAndSortOrder(string sortBy, string sortOrder)
        {
            this.model.sortBy = sortBy;
            this.model.sortOrder = sortOrder;
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
        public List<GroupModel> list()
        {
            var request = new RestRequest();
            request.Resource = "/group";
            return this.List<GroupModel>(new QueryHelper().BuildQuery<GroupQueryModel>(this.model, request));
        }

        /// <summary> Retrieves a single group.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var gr9 = camundaCl.group().Id("test").singleResult();
        /// </code>
        /// </example>
        public GroupModel singleResult()
        {
            this.ensure.NotNull("GroupId", this.model.id);
            var request = new RestRequest();
            request.Resource = "/group/" + this.model.id;
            return this.SingleResult<GroupModel>(request);
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
            this.ensure.NotNull("GroupId", this.model.id);
            var request = new RestRequest();
            if (this.model.member != null)
            {
                request.Resource = "/group/" + this.model.id + "/members/" + this.model.member;
            }
            else 
            {
                request.Resource = "/group/" + this.model.id;
            }

            request.Method = Method.DELETE;
            var resp = client.Execute(request);
            var desc = JsonConvert.DeserializeObject<RestException>(resp.Content);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = desc, StatusCode = (int)resp.StatusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = desc, StatusCode = (int)resp.StatusCode });
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
        public NoContentStatus Create(GroupModel data)
        {
            this.ensure.NotNull("groupData", data);
            var request = new RestRequest();
            request.Resource = "/group/create";
            request.Method = Method.POST;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = client.Execute(request);
            var desc = JsonConvert.DeserializeObject<RestException>(resp.Content);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = desc, StatusCode = (int)resp.StatusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = desc, StatusCode = (int)resp.StatusCode });
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
        public NoContentStatus Update(GroupModel data)
        {
            this.ensure.NotNull("groupId", this.model.id);
            this.ensure.NotNull("groupData", data);
            var request = new RestRequest();
            request.Resource = "/group/" + this.model.id;
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = client.Execute(request);
            var desc = JsonConvert.DeserializeObject<RestException>(resp.Content);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = desc, StatusCode = (int)resp.StatusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = desc, StatusCode = (int)resp.StatusCode });
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
            this.ensure.NotNull("groupId", this.model.id);
            this.ensure.NotNull("groupMemeber", this.model.member);
            var request = new RestRequest();
            request.Resource = "/group/" + this.model.id + "/members/" + this.model.member;
            request.Method = Method.PUT;
            var resp = client.Execute(request);
            var desc = JsonConvert.DeserializeObject<RestException>(resp.Content);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = desc, StatusCode = (int)resp.StatusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = desc, StatusCode = (int)resp.StatusCode });
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
            return this.Count(new QueryHelper().BuildQuery<GroupQueryModel>(this.model, request));
        }
    }
}
