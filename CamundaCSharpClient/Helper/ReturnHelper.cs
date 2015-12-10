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
        public NoContentStatus NoContentReturn(string content, HttpStatusCode statusCode)
        {
            var desc = JsonConvert.DeserializeObject<CamundaBase>(content);
            RestException exc = (desc == null) ? null : desc.RestException;
            return statusCode == System.Net.HttpStatusCode.NoContent ? (new NoContentStatus() { TNoContentStatus = TextContentStatus.Success, RestException = exc, StatusCode = (int)statusCode }) : (new NoContentStatus() { TNoContentStatus = TextContentStatus.Failed, RestException = exc, StatusCode = (int)statusCode });
        }
    }
}
