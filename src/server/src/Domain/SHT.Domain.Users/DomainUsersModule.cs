using Autofac;
using SHT.Domain.Services.Users;
using SHT.Domain.Services.Users.Accounts;
using SHT.Domain.Services.Users.Students;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Users
{
    public class DomainUsersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterFluentValidators(ThisAssembly)
                .AddAutoMapperTypes(ThisAssembly)
                .AddScopedAsImplementedInterfaces<UserEmailService>()
                .AddScopedAsImplementedInterfaces<UserAccountService>()
                .AddScopedAsImplementedInterfaces<StudentAccountService>()
                .AddScopedAsImplementedInterfaces<RegistrationValidationService>();
        }
    }
}