using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Helper
{
    public static class EnsureHelper
    {
        /// <summary>
        /// ensure the varible is not null and if it's  throw argument null exception.
        /// </summary>
        /// <param name="variableName"> the variable name to print in the exception message </param>
        /// <param name="value">value to check if null</param>
        public static void NotNull(string variableName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(variableName, "Exception has been thrown due to null value");
            }
        }
    }
}
