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
        public List<Parameter> buildQuery<T>(T query)
        {
            List<Parameter> queryParm = new List<Parameter>();
            foreach (var item in query.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (item.GetValue(query, null) == null) continue;
                Parameter parm = new Parameter();
                parm.Name = item.Name;
                parm.Value = item.GetValue(query, null);
                parm.Type = ParameterType.GetOrPost;
                queryParm.Add(parm);
                //queryString += item.Name + "=" + item.GetValue(query, null) + "&";
            }
            return queryParm;
        }
    }
}
