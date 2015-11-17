using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
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
                //// for individual resources when there's an error to make
                //// sure that RestException props are populated
                if (((int)resp.StatusCode) >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    // there is some exception like authorization Handeled By Waffle send the exception as Html
                    // so we have to handle it by deleting the html tags and add it as message in RestException
                    string restException;
                    string str;
                    var newJson = string.Empty;
                    UTF8Encoding enc = new UTF8Encoding();
                    if (resp.ContentType != "application/json")
                    {
                        restException = "{{ \"RestException\" : {{ \"type\" : \"HtmlFormatException\", \"message\" : \"{0}\" }}, \"StatusCode\" : {1} }}";

                        // override the ContentType to Json because the default deserializer for RESTSharp is XML
                        resp.ContentType = "application/json";
                        str = enc.GetString(resp.RawBytes);
                        newJson = string.Format(restException, ScrubHtml(str), (int)resp.StatusCode);
                    }
                    else 
                    { 
                        restException = "{{ \"RestException\" : {0}, \"StatusCode\" : {1} }}";
                        str = enc.GetString(resp.RawBytes);
                        newJson = string.Format(restException, str, (int)resp.StatusCode);
                    }

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

        protected static string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", string.Empty).Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            return step2;
        }
    }

    public partial class CamundaRestClient : CamundaClient
    {
        public CamundaRestClient(string baseUrl, string engineName = "default") : base(baseUrl, engineName)
        {
        }
    }
}
