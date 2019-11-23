using JetBrains.Annotations;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Application.StateMachineConfigs.StudentTestSessions.Guards;
using SHT.Application.StateMachineConfigs.StudentTestSessions.Handlers;
using SHT.Domain.Models.Tests.Students;

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
                .Use<StartStudentTestSession>();
        }
    }
}