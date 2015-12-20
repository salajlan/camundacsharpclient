using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using RestSharp;

namespace CamundaCSharpClient.Helper
{
    public static class QueryHelper
    {
        /// <summary>
        /// get the class property and if it's not null add it as a parameter to the request
        /// </summary>
        /// <returns>RestRequest</returns>
        public static RestRequest BuildQuery<T>(T query, RestRequest request)
        {            
            foreach (var item in query.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (item.GetValue(query, null) == null) 
                { 
                    continue; 
                }

                request.AddParameter(item.Name, item.GetValue(query, null));
            }

            return request;
        }
    }
}
