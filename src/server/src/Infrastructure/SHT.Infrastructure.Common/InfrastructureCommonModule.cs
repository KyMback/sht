using Autofac;
using Microsoft.Extensions.Localization;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.Common.Localization;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Infrastructure.Common
{
    public class InfrastructureCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(
                    c => c.Resolve<IStringLocalizerFactory>().Create(typeof(object)))
                .InstancePerDependency();

            builder.RegisterType<JsonStringLocalizerFactory>()
                .As<IStringLocalizerFactory>()
                .AsSelf()
                .SingleInstance();

            builder
                .AddAutoMapperTypes(ThisAssembly)
                .AddSingleAsImplementedInterfaces<DateTimeProvider>();

            builder
                .RegisterGeneric(typeof(StateManager<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}