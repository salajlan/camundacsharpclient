using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CamundaCSharpClient.Helper
{
    public class queryHelper
    {
        /// <summary>
        /// get the class property and if it's not null add it as a parameter to the request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <returns>RestRequest</returns>
        public RestRequest buildQuery<T>(T query,RestRequest request)
        {
            
            foreach (var item in query.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (item.GetValue(query, null) == null) continue;
                request.AddParameter(item.Name, item.GetValue(query, null));
            }
            return request;
        }
    }
}
