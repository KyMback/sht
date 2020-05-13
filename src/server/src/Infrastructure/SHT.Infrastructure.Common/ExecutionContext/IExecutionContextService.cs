using System;

namespace SHT.Infrastructure.Common.ExecutionContext
{
    public interface IExecutionContextService
    {
        Guid GetCurrentUserId();

        void SetExecutionContext(IExecutionContext context);
    }
}