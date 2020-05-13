using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SHT.Infrastructure.BackgroundProcess.Interfaces;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.BackgroundProcess.Jobs
{
    /// <summary>
    /// Serves as the base class for all parametrized jobs.
    /// </summary>
    /// <typeparam name="TParam">Job parameters.</typeparam>
    public abstract class BaseJob<TParam> : IJob<TParam>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Guid _id = Guid.NewGuid();
        private readonly ILogger _logger;
        private readonly string _name;

        protected BaseJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger<BaseJob<TParam>>>();
            _name = GetType().Name;
        }

        /// <inheritdoc />
        public async Task Execute(TParam param)
        {
            LogEvent("Starting execution. With default context.");
            await ExecuteInternal(param);
            LogEvent("Finishing execution.");
        }

        public async Task Execute(TParam param, IExecutionContext context)
        {
            SetContext(context);
            LogEvent($"Starting execution. With user context: {context.UserId}.");
            await ExecuteInternal(param);
            LogEvent("Finishing execution.");
        }

        /// <summary>
        /// Executes the job with the specified parameter.
        /// </summary>
        /// <param name="param">Job parameters.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task ExecuteInternal(TParam param);

        private void LogEvent(string message)
        {
            _logger.LogInformation($"Execution: {_id}, {_name}. {message}");
        }

        private void SetContext(IExecutionContext executionContext)
        {
            _serviceProvider.GetService<IExecutionContextService>().SetExecutionContext(executionContext);
        }
    }
}
