using System;

namespace SHT.Infrastructure.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}