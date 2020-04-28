using Autofac;
using SHT.Domain.Services.Tests;
using SHT.Domain.Services.Tests.Student;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Domain.Services.Tests.Variants;
using SHT.Domain.Services.Users;
using SHT.Domain.Services.Users.Accounts;
using SHT.Domain.Services.Users.Students;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services
{
    public class DomainServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterFluentValidators(ThisAssembly)
                .AddAutoMapperTypes(ThisAssembly)
                .AddScopedAsImplementedInterfaces<TestSessionService>()
                .AddScopedAsImplementedInterfaces<UserEmailService>()
                .AddScopedAsImplementedInterfaces<UserAccountService>()
                .AddScopedAsImplementedInterfaces<StudentAccountService>()
                .AddScopedAsImplementedInterfaces<StudentTestSessionService>()
                .AddScopedAsImplementedInterfaces<StudentQuestionService>()
                .AddScopedAsImplementedInterfaces<StudentQuestionValidationService>()
                .AddScopedAsImplementedInterfaces<TestVariantService>()
                .AddScopedAsImplementedInterfaces<RegistrationValidationService>();

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IBeforeCommitHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}