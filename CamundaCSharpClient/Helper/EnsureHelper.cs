using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Helper
{
    public static class EnsureHelper
    {
        public static void NotNull(string variableName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(variableName, "Exception has been thrown due to null value");
            }
        }
    }
}
