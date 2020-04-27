using Autofac;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.Services.Emails;

namespace SHT.Infrastructure.Services
{
    public class InfrastructureServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .AddAutoMapperTypes(ThisAssembly)
                .AddScopedAsImplementedInterfaces<Mailer>();
        }
    }
}