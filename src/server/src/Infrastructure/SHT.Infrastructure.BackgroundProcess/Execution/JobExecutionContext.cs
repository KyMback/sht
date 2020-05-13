using System;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Infrastructure.BackgroundProcess.Execution
{
    public class JobExecutionContext : IExecutionContext
    {
        public Guid UserId { get; set; }
    }
}
