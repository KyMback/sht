using Autofac;
using MediatR;
using MediatR.Pipeline;
using SHT.Application.Core;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterFluentValidators(ThisAssembly);
            RegisterMediator(builder);
            RegisterStateMachine(builder);
        }

        private void RegisterStateMachine(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(StateManager<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IStateConfigurationContainer<>))
                .AsImplementedInterfaces()
                .SingleInstance();
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IStateTransitionHandler<>))
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        private void RegisterMediator(ContainerBuilder builder)
        {
            builder.Register<ServiceFactory>(
                ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
            builder.AddScopedAsImplementedInterfaces<Mediator>();
            RegisterMessageHandlers(builder);
            RegisterPipeline(builder);
        }

        private void RegisterMessageHandlers(ContainerBuilder builder)
        {
            var mediatorOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatorOpenType in mediatorOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(ThisAssembly)
                    .AsClosedTypesOf(mediatorOpenType)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }
        }

        private void RegisterPipeline(ContainerBuilder builder)
        {
            // register Mediator pre- and post-processor pipelines to activate custom IRequestPreProcessor<> and IRequestPostProcessor<>
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>))
                .InstancePerDependency();
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>))
                .InstancePerDependency();

            // register custom Validation pipeline
            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>))
                .InstancePerDependency();
        }
    }
}