using Autofac;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Common
{
    public class DomainCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterFluentValidators(ThisAssembly)
                .AddAutoMapperTypes(ThisAssembly);

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IBeforeCommitHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}