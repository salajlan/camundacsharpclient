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

        public List<group> list()
        {
            var request = new RestRequest();
            request.Resource = "/group?" + new queryHelper().buildQuery<groupQuery>(this);
            return list<group>(request);
        }

        public group singleResult()
        {
            var request = new RestRequest();
            request.Resource = "/group?" + new queryHelper().buildQuery<groupQuery>(this);
            return singleResult<group>(request);
        }

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
        public noContentStatus update(group data)
        {
            ensure.ensureNotNull("groupId", this.id);
            this.ensure.ensureNotNull("groupData", data);
            var request = new RestRequest();
            request.Resource = "/group/"+this.id;
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = base.client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
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

        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/group/count?" + new queryHelper().buildQuery<groupQuery>(this);
            return count(request);
        }
    }
}
