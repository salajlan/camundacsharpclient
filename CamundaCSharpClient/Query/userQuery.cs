using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model;
using RestSharp;
using Newtonsoft.Json;

namespace CamundaCSharpClient.Query
{
    public class UserQuery : QueryBase
    {
        private EnsureHelper ensure = null;

        public UserQuery(CamundaRestClient client)
            : base(client)
        {
            this.ensure = new EnsureHelper();
        }

        protected string id { get; set; }

        protected string firstName { get; set; }

        protected string firstNameLike { get; set; }

        protected string lastName { get; set; }

        protected string lastNameLike { get; set; }

        protected string email { get; set; }

        protected string emailLike { get; set; }

        protected string memberOfGroup { get; set; }

        protected string sortBy { get; set; }

        protected string sortOrder { get; set; }

        protected int? firstResult { get; set; }

        protected int? maxResults { get; set; }

        public UserQuery Id(string id)
        {
            this.id = id;
            return this;
        }

        public UserQuery FirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public UserQuery FirstNameLike(string firstNameLike)
        {
            this.firstNameLike = firstNameLike;
            return this;
        }

        public UserQuery LastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public UserQuery LastNameLike(string lastNameLike)
        {
            this.lastNameLike = lastNameLike;
            return this;
        }

        public UserQuery Email(string email)
        {
            this.email = email;
            return this;
        }

        public UserQuery EmailLike(string emailLike)
        {
            this.emailLike = emailLike;
            return this;
        }

        public UserQuery MemberOfGroup(string memberOfGroup)
        {
            this.memberOfGroup = memberOfGroup;
            return this;
        }

        public UserQuery sortByNSortOrder(string sortBy, string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }

        public UserQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }

        public UserQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }
        
        /// <summary>
        /// Deletes a user by id.
        /// </summary>
        /// <returns>NoContentStatus</returns>
        public NoContentStatus Delete()
        {
            this.ensure.NotNull("Id", this.id);

            var request = new RestRequest();
            request.Resource = "/user/" + this.id;
            request.Method = Method.DELETE;
            var resp = this.client.Execute(request);
            var desc = JsonConvert.DeserializeObject<RestException>(resp.Content);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = desc, StatusCode = (int)resp.StatusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = desc, StatusCode = (int)resp.StatusCode });
        }

        /// <summary>
        /// Retrieves a single user's profile.
        /// </summary>
        /// <returns>User</returns>
        public User Profile()
        {
            this.ensure.NotNull("Id", this.id);

            var request = new RestRequest();
            request.Resource = "/user/" + this.id + "/profile";
            request.Method = Method.GET;
            return this.SingleResult<User>(request);
        }

        /// <summary>
        /// Query for a list of users using a list of parameters. The size of the result set can be retrieved by using the get users count method.
        /// </summary>
        /// <returns>List<User></returns>
        public List<User> list()
        {
            var request = new RestRequest();
            request.Resource = "/user";
            request = new QueryHelper().BuildQuery<UserQuery>(this, request);
            return this.List<User>(request);
        }

        /// <summary>
        /// Query for users using a list of parameters and retrieves the count.
        /// </summary>
        /// <returns>Count</returns>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/user/count";
            request = new QueryHelper().BuildQuery<UserQuery>(this, request);
            return this.Count(request);
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="userData"> user data to create </param>
        /// <param name="password"> pass </param>
        /// <returns>NoContentStatus</returns>
        public NoContentStatus Create(User userData, string password)
        {
            this.ensure.NotNull("UserData", userData);
            this.ensure.NotNull("password", password);

            var request = new RestRequest();
            request.Resource = "/user/create";
            request.Method = Method.POST;
            object obj = new { profile = userData, credentials = new { password = password } };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = this.client.Execute(request);
            var desc = JsonConvert.DeserializeObject<RestException>(resp.Content);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = desc, StatusCode = (int)resp.StatusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = desc, StatusCode = (int)resp.StatusCode });
        }

        public NoContentStatus Update(User updatedData)
        {
            this.ensure.NotNull("UserId", this.id);
            this.ensure.NotNull("UserData", updatedData);

            var request = new RestRequest();
            request.Resource = "/user/" + this.id + "/profile";
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(updatedData);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = this.client.Execute(request);
            var desc = JsonConvert.DeserializeObject<RestException>(resp.Content);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = desc, StatusCode = (int)resp.StatusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = desc, StatusCode = (int)resp.StatusCode });
        }
    }
}
