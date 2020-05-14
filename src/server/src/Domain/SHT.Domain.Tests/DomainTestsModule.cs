using Autofac;
using SHT.Domain.Services.Student;
using SHT.Domain.Services.Student.Questions;
using SHT.Domain.Services.TestSessionAssessments;
using SHT.Domain.Services.Variants;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.Common.StateMachine.Core;
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
                .AddScopedAsImplementedInterfaces<TestSessionAssessmentService>()
                .AddScopedAsImplementedInterfaces<QuestionsAnswersRatingService>()
                .AddScopedAsImplementedInterfaces<QuestionsAnswersRatingValidationService>()
                .AddScopedAsImplementedInterfaces<StudentTestSessionService>()
                .AddScopedAsImplementedInterfaces<StudentQuestionService>()
                .AddScopedAsImplementedInterfaces<StudentQuestionValidationService>()
                .AddScopedAsImplementedInterfaces<TestVariantService>();

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IBeforeCommitHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            RegisterStateMachine(builder);
        }

        private void RegisterStateMachine(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IStateConfigurationContainer<>))
                .AsImplementedInterfaces()
                .SingleInstance();
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IStateTransitionHandler<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IStateTransitionGuard<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}