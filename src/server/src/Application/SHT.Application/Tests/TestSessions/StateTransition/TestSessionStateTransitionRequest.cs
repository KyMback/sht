using System;
using MediatR;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.StateTransition
{
    [ApiDataContract]
    public class TestSessionStateTransitionRequest : IRequest
    {
        public Guid TestSessionId { get; set; }

        public string Trigger { get; set; }
    }
}