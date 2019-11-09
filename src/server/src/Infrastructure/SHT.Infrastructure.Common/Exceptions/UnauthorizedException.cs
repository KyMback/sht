namespace SHT.Infrastructure.Common.Exceptions
{
    public class UnauthorizedException : BusinessException
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}