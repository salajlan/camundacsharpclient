using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public enum TextContentStatus
    {
        Success,
        Failed
    }

    public class NoContentStatus : CamundaBase
    {
        public TextContentStatus TNoContentStatus
        {
            get;
            set;
        }
    }
}
