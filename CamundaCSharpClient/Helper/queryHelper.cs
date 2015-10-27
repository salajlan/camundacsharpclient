using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CamundaCSharpClient.Helper
{
    public class queryHelper
    {
        public string buildQuery<T>(T query)
        {
            string queryString = null;
            foreach (var item in query.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (item.GetValue(query, null) == null) continue;
                queryString += item.Name + "=" + item.GetValue(query, null) + "&";
            }
            return queryString;
        }
    }
}
