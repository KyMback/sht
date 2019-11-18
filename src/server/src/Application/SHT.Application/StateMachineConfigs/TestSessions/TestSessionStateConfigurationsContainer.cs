using JetBrains.Annotations;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Application.StateMachineConfigs.TestSessions.Handlers;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Application.StateMachineConfigs.TestSessions
{
    [UsedImplicitly]
    internal class TestSessionStateConfigurationsContainer : IStateConfigurationContainer<TestSession>
    {
        public void Configure(IStateConfigurationsBuilder<TestSession> builder)
        {
            builder.Configure()
                .From(TestSessionStates.Pending)
                .To(TestSessionStates.Started)
                .WithTrigger(TestSessionTriggers.StartTest)
                .Use<StartTestSessionHandler>();
        }
    }
}