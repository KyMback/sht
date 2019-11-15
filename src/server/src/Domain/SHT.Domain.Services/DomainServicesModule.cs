using Autofac;
using SHT.Domain.Services.Tests;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Services
{
    public class DomainServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .AddScopedAsImplementedInterfaces<TestSessionService>()
                .AddScopedAsImplementedInterfaces<RegistrationValidationService>();
        }
    }
}