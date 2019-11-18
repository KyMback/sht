using System;
using MediatR;

namespace SHT.Application.Tests.TestSessions.StateTransition
{
    public class TestSessionStateTransitionRequest : IRequest
    {
        public Guid TestSessionId { get; set; }

        public string Trigger { get; set; }
    }
}