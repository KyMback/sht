using System;

namespace SHT.Infrastructure.Common
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }

        DateTime PlatformNow { get; }
    }
}