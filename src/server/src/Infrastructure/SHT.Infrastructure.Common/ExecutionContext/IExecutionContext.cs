using System;

namespace SHT.Infrastructure.Common.ExecutionContext
{
    public interface IExecutionContext
    {
        Guid UserId { get; set; }
    }
}
