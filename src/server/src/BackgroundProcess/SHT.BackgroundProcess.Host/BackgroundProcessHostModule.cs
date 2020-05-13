using Autofac;
using Hangfire;
using SHT.BackgroundProcess.Host.Services;
using SHT.Infrastructure.BackgroundProcess.Execution;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.BackgroundProcess.Host
{
    /// <inheritdoc />
    public class BackgroundProcessHostModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JobExecutor>()
                .As<IJobExecutor>()
                .InstancePerBackgroundJob();

            builder
                .AddSingle<IRecurringJobManager, RecurringJobManager>()
                .AddSingleAsImplementedInterfaces<BackgroundHostInjectionResolver>()
                .AddScopedAsImplementedInterfaces<BackgroundHostExecutionContextService>();

            base.Load(builder);
        }
    }
}
