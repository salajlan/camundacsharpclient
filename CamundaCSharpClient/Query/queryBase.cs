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
        protected CamundaRestClient client;

        public QueryBase(CamundaRestClient client)
        {
            this.client = client;
        }        

        protected List<T> List<T>(IRestRequest request)
        {
            return this.client.Execute<List<T>>(request);
        }
        
        protected T SingleResult<T>(IRestRequest request) where T : new()
        {
            return this.client.Execute<T>(request);
        }

        protected Count Count(IRestRequest request)
        {
            return this.client.Execute<Count>(request);
        }
    }
}
