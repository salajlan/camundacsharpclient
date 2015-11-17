using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace CamundaCSharpClient.Model
{
    public class CamundaBase
    {
        public RestException RestException { get; set; }

        public int StatusCode { get; set; }
    }
}
