using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using RestSharp;

namespace CamundaCSharpClient
{
    public partial class camundaRestClient
    {
        /// <summary>
        /// Retrieve the groups data by different filter parameter.
        /// If there is no parameter it will retrieve all groups available
        /// It can be filter two paramter or more ex : getGroup(member:"demo",name:"Sales");
        /// </summary>
        /// <param name="id">The id of the group to retrieve</param>
        /// <param name="name">The name of the group to retrieve</param>
        /// <param name="nameLike">The nameLike of the group to retrieve</param>
        /// <param name="type">The type of the group to retrieve</param>
        /// <param name="member">member of this group to retrive</param>
        /// <param name="maxResults">maximum result to retrive</param>
        /// <param name="sortBy">sort By id,name,type -- it has to define sortOrder parameter</param>
        /// <param name="sortOrder">sort order asc desc -- it has to define sortBy parameter</param>
        public List<group> getGroup(string id = null, string name = null, string nameLike = null, string type = null, string member = null, int? maxResults = null, string sortBy = null, string sortOrder = null)
        {
            var request = new RestRequest();
            string groupCondition = null;
            if (id != null) groupCondition = "id="+id+"&";
            if (name != null) groupCondition += "name=" + name+"&";
            if (nameLike != null) groupCondition += "nameLike=" + nameLike + "&";
            if (type != null) groupCondition += "type=" + type + "&";
            if (member != null) groupCondition += "member=" + member + "&";
            if (maxResults != null) groupCondition += "maxResults=" + maxResults + "&";
            if (sortBy != null && sortOrder != null) groupCondition += "sortBy=" + sortBy + "&sortOrder=" + sortOrder + "&";

            request.Resource = "/group?" + groupCondition;

            return Execute<List<group>>(request);
        }
    }
}
