using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Helper
{
    public class EnsureHelper
    {
        public void ensureNotNull(string variableName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(variableName, "Exception has been thrown due to null value");
            }
        }
    }
}
