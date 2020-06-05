using System;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Infrastructure.BackgroundProcess.Execution
{
    public class JobExecutionContext : IExecutionContext
    {
        public JobExecutionContext(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
