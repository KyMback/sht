using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.TestSessions.Students.StateTransition
{
    public class StudentTestSessionStateTransitionRequest : IRequest
    {
        public Guid StudentTestSessionId { get; set; }

        public string Trigger { get; set; }

        public IDictionary<string, string> SerializedData { get; set; }
    }
}