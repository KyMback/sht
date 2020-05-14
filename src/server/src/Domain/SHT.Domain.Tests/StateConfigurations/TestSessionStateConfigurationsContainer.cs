using JetBrains.Annotations;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Services.StateConfigurations.Guards;
using SHT.Domain.Services.StateConfigurations.Handlers;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Domain.Services.StateConfigurations
{
    [UsedImplicitly]
    internal class TestSessionStateConfigurationsContainer : IStateConfigurationContainer<TestSession>
    {
        public void Configure(IStateConfigurationBuilder<TestSession> builder)
        {
            builder.Configure()
                .From(TestSessionState.Pending)
                .To(TestSessionState.Started)
                .WithTrigger(TestSessionTriggers.StartTest)
                .WithGuard<InstructorIsOwner>();

            builder.Configure()
                .From(TestSessionState.Started)
                .To(TestSessionState.Assessment)
                .WithTrigger(TestSessionTriggers.StartAssessment)
                .WithGuard<InstructorIsOwner>()
                .Use<StartAssessmentPhaseHandler>();

            builder.Configure()
                .From(TestSessionState.Assessment)
                .To(TestSessionState.Ended)
                .WithTrigger(TestSessionTriggers.EndTest)
                .WithGuard<InstructorIsOwner>();
        }
    }
}