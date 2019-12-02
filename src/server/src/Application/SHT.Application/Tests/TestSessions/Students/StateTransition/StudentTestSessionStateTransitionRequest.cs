using System;
using System.Collections.Generic;
using MediatR;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Students.StateTransition
{
    [ApiDataContract]
    public class StudentTestSessionStateTransitionRequest : IRequest
    {
        public Guid StudentTestSessionId { get; set; }

        public string Trigger { get; set; }

        public IDictionary<string, string> SerializedData { get; set; }
    }
}