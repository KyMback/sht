using System;

namespace SHT.Infrastructure.Common
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime PlatformNow => DateTime.Now;
    }
}