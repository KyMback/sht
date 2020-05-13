using System;
using Hangfire;
using Hangfire.Common;
using Microsoft.Extensions.Configuration;
using SHT.Infrastructure.BackgroundProcess.Interfaces;

namespace SHT.BackgroundProcess.Host.Extensions
{
    /// <summary>
    /// Hangfire recurring jobs manager extensions.
    /// </summary>
    public static class RecurringJobManagerExtensions
    {
        public static void AddOrUpdate<T>(this IRecurringJobManager jobManager, string jobId, IConfiguration configuration)
            where T : IRecurringJob
        {
            string cronExpression = GetCronExpression(configuration, jobId);
            jobManager.AddOrUpdate(jobId, Job.FromExpression<T>(job => job.Execute()), cronExpression);
        }

        public static void AddOrUpdate<T>(this IRecurringJobManager jobManager, string jobId, IConfiguration configuration, TimeZoneInfo timeZone)
            where T : IRecurringJob
        {
            string cronExpression = GetCronExpression(configuration, jobId);
            jobManager.AddOrUpdate(jobId, Job.FromExpression<T>(job => job.Execute()), cronExpression, timeZone);
        }

        private static string GetCronExpression(IConfiguration configuration, string jobId)
        {
            return configuration.GetValue<string>($"RecurringJobs:{jobId}");
        }
    }
}
