using Autofac;
using SHT.Domain.Services.Tests;
using SHT.Domain.Services.Tests.Student;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Domain.Services.Users;
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
                .AddScopedAsImplementedInterfaces<TestSessionService>()
                .AddScopedAsImplementedInterfaces<StudentTestSessionService>()
                .AddScopedAsImplementedInterfaces<StudentQuestionService>()
                .AddScopedAsImplementedInterfaces<RegistrationValidationService>();

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IBeforeCommitHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}