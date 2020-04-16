using System;
using MediatR;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.StateTransition
{
    [ApiDataContract]
    public class TestSessionStateTransitionRequest : IRequest
    {
        public TestSessionStateTransitionRequest(Guid testSessionId, string trigger)
        {
            TestSessionId = testSessionId;
            Trigger = trigger;
        }

        public Guid TestSessionId { get; set; }

        public string Trigger { get; set; }
    }
}