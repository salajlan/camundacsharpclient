using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using CamundaCSharpClient.Helper;

namespace CamundaCSharpClient
{
    public abstract partial class CamundaClient
    {
        private RestClient _client;

        public CamundaClient(string baseUrl, string engineName = "default")
        {
            this.BaseUrl = baseUrl;
            this.EngineName = engineName;

            this._client = new RestClient();
            this._client.AddDefaultHeader("Content-Type", "application/json");
            this._client.AddDefaultHeader("Accept", "application/json");
            this._client.UserAgent = "camundaRestClient - .net";

            this._client.BaseUrl = new Uri(baseUrl + "/engine/" + engineName);
            this._client.Timeout = 30500;
        }

        private string BaseUrl { get; set; }

        private string EngineName { get; set; }

        public virtual T Execute<T>(IRestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = (resp) =>
            {
                resp.ContentType = "application/json";
                //// for individual resources when there's an error to make
                //// sure that RestException props are populated
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

            var response = this._client.Execute<T>(request);
            return response.Data;
        }

        public void Authenticator()
        {
            this._client.Authenticator = new NtlmAuthenticator();
        }

        public void Authenticator(ICredentials credentials)
        {
            new EnsureHelper().NotNull("credentials", credentials);
            this._client.Authenticator = new NtlmAuthenticator(credentials);
        }

        public void Authenticator(string userName, string password)
        {
            this._client.Authenticator = new HttpBasicAuthenticator(userName, password);
        }

        public virtual IRestResponse Execute(IRestRequest request)
        {
            return this._client.Execute(request);
        }
    }

    public partial class CamundaRestClient : CamundaClient
    {
        public CamundaRestClient(string baseUrl, string engineName = "default") : base(baseUrl, engineName)
        {
        }
    }
}
