using System;

namespace SHT.Infrastructure.Common
{
    public interface IExecutionContextAccessor
    {
        Guid GetCurrentUserId();
    }
}