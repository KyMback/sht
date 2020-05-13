using System;
using JetBrains.Annotations;

namespace SHT.Common.Utils
{
    public static class Assert
    {
        public static void NotNull(object obg, [InvokerParameterName] string paramName, string message = default)
        {
            if (obg == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }
    }
}