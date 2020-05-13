using Autofac;
using SHT.Domain.Users.Accounts;
using SHT.Domain.Users.Instructors;
using SHT.Domain.Users.Students;
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
                .AddScopedAsImplementedInterfaces<InstructorAccountService>()
                .AddScopedAsImplementedInterfaces<StudentAccountService>()
                .AddScopedAsImplementedInterfaces<RegistrationValidationService>();
        }
    }
}