using JetBrains.Annotations;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Application.StateMachineConfigs.TestSessions.Guards;
using SHT.Application.StateMachineConfigs.TestSessions.Handlers;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;

namespace SHT.Application.StateMachineConfigs.TestSessions
{
    [UsedImplicitly]
    internal class TestSessionStateConfigurationsContainer : IStateConfigurationContainer<TestSession>
    {
        public void Configure(IStateConfigurationBuilder<TestSession> builder)
        {
            builder.Configure()
                .From(TestSessionStates.Pending)
                .To(TestSessionStates.Started)
                .WithTrigger(TestSessionTriggers.StartTest)
                .WithGuard<InstructorIsOwner>()
                .Use<StartTestSessionHandler>();

            builder.Configure()
                .From(TestSessionStates.Started)
                .To(TestSessionStates.Ended)
                .WithTrigger(TestSessionTriggers.EndTest)
                .WithGuard<InstructorIsOwner>()
                .Use<EndTestSessionHandler>();
        }
    }
}