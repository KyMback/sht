using Autofac;
using SHT.Domain.Services.Tests;
using SHT.Domain.Services.Tests.Student;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services
{
    public class DomainTestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterFluentValidators(ThisAssembly)
                .AddAutoMapperTypes(ThisAssembly)
                .AddScopedAsImplementedInterfaces<TestSessionService>()
                .AddScopedAsImplementedInterfaces<StudentTestSessionService>()
                .AddScopedAsImplementedInterfaces<StudentQuestionService>()
                .AddScopedAsImplementedInterfaces<StudentQuestionValidationService>()
                .AddScopedAsImplementedInterfaces<TestVariantService>();

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IBeforeCommitHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}