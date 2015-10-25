using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace CamundaCSharpClient
{
    public abstract partial class camundaClient
    {
        public string baseUrl { get; private set; }
        public string engineName { get; private set; }

        protected RestClient _client;

        public camundaClient(string BaseUrl, string EngineName = "default")
        {
            baseUrl = BaseUrl;
            engineName = EngineName;

            _client = new RestClient();
            _client.AddDefaultHeader("Content-Type", "application/json");
            _client.AddDefaultHeader("Accept", "application/json");
            _client.UserAgent = "camundaRestClient - .net";

            _client.BaseUrl = new Uri(baseUrl + "/engine/"+engineName);
            _client.Timeout = 30500;
        }

        public virtual T Execute<T>(IRestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = (resp) =>
            {
                resp.ContentType = "application/json";
                // for individual resources when there's an error to make
                // sure that RestException props are populated
                if (((int)resp.StatusCode) >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    string restException = "{{ \"RestException\" : {0} }}";
                    UTF8Encoding enc = new UTF8Encoding();
                    string str = enc.GetString(resp.RawBytes);
                    var newJson = string.Format(restException, str);
                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                }
            };

            var response = _client.Execute<T>(request);
            return response.Data;
        }

        public void Authenticator()
        {
            _client.Authenticator = new NtlmAuthenticator();
        }
        public void Authenticator(ICredentials credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            _client.Authenticator = new NtlmAuthenticator();
        }
        public void Authenticator(string userName, string password)
        {
            _client.Authenticator = new HttpBasicAuthenticator(userName, password);
        }

        public virtual IRestResponse Execute(IRestRequest request)
        {
            return _client.Execute(request);
        }
    }


    public partial class camundaRestClient : camundaClient
    {
        public camundaRestClient(string BaseUrl, string EngineName = "default") :base(BaseUrl,EngineName)
        {
        }
    }
}
