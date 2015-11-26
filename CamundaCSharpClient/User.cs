using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Query;

namespace CamundaCSharpClient
{
    public partial class CamundaRestClient
    {
        public UserQuery User()
        {
            return new UserQuery(this);
        }
    }
}
