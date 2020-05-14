using JetBrains.Annotations;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services.Student.StateConfigurations.Guards;
using SHT.Domain.Services.Student.StateConfigurations.Handlers;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Domain.Services.Student.StateConfigurations
{
    [UsedImplicitly]
    internal class StudentTestSessionStateConfigurationsContainer : IStateConfigurationContainer<StudentTestSession>
    {
        public void Configure(IStateConfigurationBuilder<StudentTestSession> builder)
        {
            builder
                .Configure()
                .From(StudentTestSessionState.Pending)
                .To(StudentTestSessionState.Started)
                .WithTrigger(StudentTestSessionTriggers.StartTest)
                .WithGuard<TestSessionIsStartedGuard>()
                .WithGuard<CurrentUserIsOwnerGuard>()
                .Use<StartStudentTestSession>();

            builder
                .Configure()
                .From(StudentTestSessionState.Pending)
                .To(StudentTestSessionState.Ended)
                .WithTrigger(StudentTestSessionTriggers.OverdueTest)
                .WithGuard<CurrentUserIsTestSessionOwner>();

            builder
                .Configure()
                .From(StudentTestSessionState.Started)
                .To(StudentTestSessionState.Ended)
                .WithTrigger(StudentTestSessionTriggers.EndTest)
                .WithGuard<CurrentUserIsOwnerOrTestSessionOwnerGuard>();
        }
    }
}