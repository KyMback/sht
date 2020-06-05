using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SHT.BackgroundProcess.Host.Extensions;
using SHT.BackgroundProcess.Jobs.RecurringJobs;

namespace SHT.BackgroundProcess.Host.Services.Hosted
{
    /// <summary>
    /// Registers recurring jobs for execution.
    /// </summary>
    public class RecurringJobsService : IHostedService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RecurringJobsService> _logger;

        public RecurringJobsService(
            ILogger<RecurringJobsService> logger,
            IRecurringJobManager recurringJobManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _recurringJobManager = recurringJobManager;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting {nameof(RecurringJobsService)}");

            ClearJobs();
            RegisterJobs();

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Stopping {nameof(RecurringJobsService)}");

            ClearJobs();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Cleans up all recurring jobs that have been started by this server
        /// to prevent jobs from being processed multiple times.
        /// </summary>
        private void ClearJobs()
        {
            List<RecurringJobDto> recurringJobs = JobStorage.Current.GetConnection().GetRecurringJobs();
            recurringJobs.ForEach(job => _recurringJobManager.RemoveIfExists(job.Id));
        }

        private void RegisterJobs()
        {
            _recurringJobManager.AddOrUpdate<FinalizeStudentsTestSessionsJob>(nameof(FinalizeStudentsTestSessionsJob), _configuration);
        }
    }
}
