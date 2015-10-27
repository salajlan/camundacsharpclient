using CamundaCSharpClient.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Query
{
    public class queryBase
    {
        protected camundaRestClient client;
        public queryBase(camundaRestClient client)
        {
            this.client = client;
        }
        protected List<T> list<T>(IRestRequest request)
        {
            return client.Execute<List<T>>(request);
        }

        protected T singleResult<T>(IRestRequest request) where T : new()
        {
            return client.Execute<T>(request);
        }
        protected Count count(IRestRequest request)
        {
            return client.Execute<Count>(request);
        }
    }
}
