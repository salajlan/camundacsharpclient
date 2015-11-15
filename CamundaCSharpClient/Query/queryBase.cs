using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using RestSharp;

namespace CamundaCSharpClient.Query
{
    public class QueryBase
    {
        public QueryBase(CamundaRestClient client)
        {
            this.Client = client;
        }

        protected CamundaRestClient Client { get; set; }

        protected List<T> List<T>(IRestRequest request)
        {
            return this.Client.Execute<List<T>>(request);
        }
        
        protected T SingleResult<T>(IRestRequest request) where T : new()
        {
            return this.Client.Execute<T>(request);
        }

        protected Count Count(IRestRequest request)
        {
            return this.Client.Execute<Count>(request);
        }
    }
}
