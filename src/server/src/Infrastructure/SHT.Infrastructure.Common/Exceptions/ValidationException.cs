using System.Collections.Generic;

namespace SHT.Infrastructure.Common.Exceptions
{
    public class ValidationException : BusinessException
    {
        public ValidationException(IEnumerable<string> errorList)
            : base(default, default, errorList)
        {
        }

        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}