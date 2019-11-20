using System;
using MediatR;

namespace SHT.Application.Tests.TestSessions.Students.StateTransition
{
    public class StudentTestSessionStateTransitionRequest : IRequest
    {
        public Guid StudentTestSessionId { get; set; }

        public string Trigger { get; set; }
    }
}