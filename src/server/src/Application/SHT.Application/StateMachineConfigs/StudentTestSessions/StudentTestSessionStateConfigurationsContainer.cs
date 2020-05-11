using JetBrains.Annotations;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Application.StateMachineConfigs.StudentTestSessions.Guards;
using SHT.Application.StateMachineConfigs.StudentTestSessions.Handlers;
using SHT.Domain.Models.TestSessions.Students;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions
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