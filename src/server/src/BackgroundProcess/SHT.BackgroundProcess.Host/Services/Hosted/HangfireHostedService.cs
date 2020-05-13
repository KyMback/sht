using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SHT.BackgroundProcess.Host.Services.Hosted
{
    internal class HangfireHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<HangfireHostedService> _logger;
        private BackgroundJobServer _server;

        public HangfireHostedService(ILogger<HangfireHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting {nameof(HangfireHostedService)}");
            _server = new BackgroundJobServer();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Stopping {nameof(HangfireHostedService)}");

            Dispose();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _server?.Dispose();
        }
    }
}
