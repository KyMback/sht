using System;

namespace SHT.Infrastructure.Common
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime PlatformNow => DateTime.Now;
    }
}