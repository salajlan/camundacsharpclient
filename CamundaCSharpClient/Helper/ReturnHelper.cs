using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using CamundaCSharpClient.Model;
using Newtonsoft.Json;

namespace CamundaCSharpClient.Helper
{
    public class ReturnHelper
    {
        /// <summary>
        /// when the camunda REST API return is no content status (204) we will call this methos to deserlize the content of the request if it
        /// has content that means that request has an error so we have to descerlize it and send it as CamundaBase if its null then 
        /// send it as normal
        /// </summary>
        /// <param name="content">Request content</param>
        /// <param name="statusCode"> status Code of the request</param>
        /// <returns>NoContentStatus</returns>
        public static NoContentStatus NoContentReturn(string content, HttpStatusCode statusCode)
        {
            var desc = JsonConvert.DeserializeObject<CamundaBase>(content);
            RestException exc = (desc == null) ? null : desc.RestException;
            return statusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = exc, StatusCode = (int)statusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = exc, StatusCode = (int)statusCode });
        }
    }
}
