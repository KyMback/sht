using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SHT.Infrastructure.BackgroundProcess.Interfaces;

namespace SHT.BackgroundProcess.Jobs
{
    public abstract class BaseRecurringJob : IRecurringJob
    {
        private readonly Guid _id = Guid.NewGuid();
        private readonly ILogger _logger;
        private readonly string _name;

        protected BaseRecurringJob(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetRequiredService<ILogger<BaseRecurringJob>>();
            _name = GetType().Name;
        }

        public async Task Execute()
        {
            LogEvent("Starting execution.");

            await ExecuteInternal();

            LogEvent("Finishing execution.");
        }

        protected abstract Task ExecuteInternal();

        private void LogEvent(string message)
        {
            _logger.LogInformation($"Execution: {_id}, {_name}. {message}");
        }
    }
}
