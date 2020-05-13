using System;
using Hangfire;
using SHT.Infrastructure.BackgroundProcess.Interfaces;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Infrastructure.BackgroundProcess.Execution
{
    /// <summary>
    /// Implements <see cref="IBackgroundExecutionService"/> using Hangfire background jobs.
    /// </summary>
    public class HangfireBackgroundExecutionService : IBackgroundExecutionService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public HangfireBackgroundExecutionService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public void Execute<TParam>(string name, TParam param)
        {
            _backgroundJobClient.Enqueue<IJobExecutor>(job => job.Execute(name, param));
        }

        public void Execute<TParam>(string name, TParam param, IExecutionContext context)
        {
            _backgroundJobClient.Enqueue<IJobExecutor>(job => job.Execute(name, param, context));
        }

        /// <inheritdoc />
        public void Schedule<TParam>(string name, TParam param, DateTime executeAt)
        {
            _backgroundJobClient.Schedule<IJobExecutor>(job => job.Execute(name, param), executeAt);
        }

        public void Schedule<TParam>(string name, TParam param, DateTime executeAt, IExecutionContext context)
        {
            _backgroundJobClient.Schedule<IJobExecutor>(job => job.Execute(name, param, context), executeAt);
        }
    }
}
