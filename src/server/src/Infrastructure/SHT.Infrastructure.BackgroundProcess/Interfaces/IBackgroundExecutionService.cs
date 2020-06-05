using System;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Infrastructure.BackgroundProcess.Interfaces
{
    /// <summary>
    /// Defines an interface that allows to execute background jobs with custom parameters and execution context.
    /// </summary>
    public interface IBackgroundExecutionService
    {
        /// <summary>
        /// Registers the job for execution.
        /// </summary>
        /// <typeparam name="TParam">The job parameter type.</typeparam>
        /// <param name="name">The job name.</param>
        /// <param name="param">The job parameter.</param>
        void Execute<TParam>(string name, TParam param);

        void Execute<TParam>(string name, TParam param, IExecutionContext context);

        /// <summary>
        /// Schedules the job for execution at specified time.
        /// </summary>
        /// <typeparam name="TParam">The job parameter type.</typeparam>
        /// <param name="name">The job name.</param>
        /// <param name="param">The job parameter.</param>
        /// <param name="executeAt">Date and time when the job should be executed.</param>
        void Schedule<TParam>(string name, TParam param, DateTime executeAt);
    }
}
