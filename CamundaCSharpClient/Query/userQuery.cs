using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Helper;
using CamundaCSharpClient.Model;
using RestSharp;
using Newtonsoft.Json;
using CamundaCSharpClient.Model.Task;

namespace CamundaCSharpClient.Query
{
    public class UserQuery : QueryBase
    {
        private UserQueryModel model = new UserQueryModel();

        public UserQuery(CamundaRestClient client)
            : base(client)
        {
        }

        public UserQuery Id(string id)
        {
            this.model.id = id;
            return this;
        }

        public UserQuery FirstName(string firstName)
        {
            this.model.firstName = firstName;
            return this;
        }

        public UserQuery FirstNameLike(string firstNameLike)
        {
            this.model.firstNameLike = firstNameLike;
            return this;
        }

        public UserQuery LastName(string lastName)
        {
            this.model.lastName = lastName;
            return this;
        }

        public UserQuery LastNameLike(string lastNameLike)
        {
            this.model.lastNameLike = lastNameLike;
            return this;
        }

        public UserQuery Email(string email)
        {
            this.model.email = email;
            return this;
        }

        public UserQuery EmailLike(string emailLike)
        {
            this.model.emailLike = emailLike;
            return this;
        }

        public UserQuery MemberOfGroup(string memberOfGroup)
        {
            this.model.memberOfGroup = memberOfGroup;
            return this;
        }

        public UserQuery sortByNSortOrder(UserQueryModel.SortByValue sortBy, string sortOrder)
        {
            this.model.sortBy = Enum.GetName(sortBy.GetType(), sortBy);
            this.model.sortOrder = sortOrder;
            return this;
        }

        public UserQuery FirstResult(int firstResult)
        {
            this.model.firstResult = firstResult;
            return this;
        }

        public UserQuery MaxResults(int maxResults)
        {
            this.model.maxResults = maxResults;
            return this;
        }
        
        /// <summary>
        /// Deletes a user by id.
        /// </summary>
        /// <returns>NoContentStatus</returns>
        public NoContentStatus Delete()
        {
            EnsureHelper.NotNull("Id", this.model.id);

            var request = new RestRequest();
            request.Resource = "/user/" + this.model.id;
            request.Method = Method.DELETE;
            var resp = this.client.Execute(request);
            var desc = JsonConvert.DeserializeObject<CamundaBase>(resp.Content);
            return ReturnHelper.NoContentReturn(resp.Content, resp.StatusCode);
        }

        /// <summary>
        /// Retrieves a single user's profile.
        /// </summary>
        /// <returns>User</returns>
        public UserModel Profile()
        {
            EnsureHelper.NotNull("Id", this.model.id);

            var request = new RestRequest();
            request.Resource = "/user/" + this.model.id + "/profile";
            request.Method = Method.GET;
            return this.SingleResult<UserModel>(request);
        }

        /// <summary>
        /// Query for a list of users using a list of parameters. The size of the result set can be retrieved by using the get users count method.
        /// </summary>
        /// <returns>List<User></returns>
        public List<UserModel> list()
        {
            var request = new RestRequest();
            request.Resource = "/user";
            request = QueryHelper.BuildQuery<UserQueryModel>(this.model, request);
            return this.List<UserModel>(request);
        }

        /// <summary>
        /// Query for users using a list of parameters and retrieves the count.
        /// </summary>
        /// <returns>Count</returns>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/user/count";
            request = QueryHelper.BuildQuery<UserQueryModel>(this.model, request);
            return this.Count(request);
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="userData"> user data to create </param>
        /// <param name="password"> pass </param>
        /// <returns>NoContentStatus</returns>
        public NoContentStatus Create(UserModel userData, string password)
        {
            EnsureHelper.NotNull("UserData", userData);
            EnsureHelper.NotNull("password", password);

            var request = new RestRequest();
            request.Resource = "/user/create";
            request.Method = Method.POST;
            object obj = new { profile = userData, credentials = new { password = password } };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = this.client.Execute(request);
            return ReturnHelper.NoContentReturn(resp.Content, resp.StatusCode);
        }

        public NoContentStatus Update(UserModel updatedData)
        {
            EnsureHelper.NotNull("UserId", this.model.id);
            EnsureHelper.NotNull("UserData", updatedData);

            var request = new RestRequest();
            request.Resource = "/user/" + this.model.id + "/profile";
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(updatedData);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = this.client.Execute(request);
            return ReturnHelper.NoContentReturn(resp.Content, resp.StatusCode);
        }
    }
}
