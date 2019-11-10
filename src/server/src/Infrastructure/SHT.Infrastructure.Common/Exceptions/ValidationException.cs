using System;
using System.Collections.Generic;
using System.Linq;

namespace SHT.Infrastructure.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<string> errorList)
            : base(errorList.Aggregate(string.Empty, (s, s1) => string.Concat(s, " ", s1)))
        {
        }

        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}