using Autofac;
using Hangfire;
using SHT.Infrastructure.BackgroundProcess.Execution;
using SHT.Infrastructure.BackgroundProcess.Interfaces;

namespace SHT.Infrastructure.BackgroundProcess
{
    public class InfrastructureBackgroundProcessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HangfireBackgroundExecutionService>()
                .As<IBackgroundExecutionService>()
                .SingleInstance();

            builder.RegisterType<BackgroundJobClient>()
                .As<IBackgroundJobClient>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
