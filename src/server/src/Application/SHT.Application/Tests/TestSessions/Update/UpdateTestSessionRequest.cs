using System;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.Update
{
    public class UpdateTestSessionRequest : IRequest
    {
        public UpdateTestSessionRequest(TestSessionModificationDataDto data, Guid testSessionId)
        {
            Data = data;
            TestSessionId = testSessionId;
        }

        public Guid TestSessionId { get; set; }

        public TestSessionModificationDataDto Data { get; set; }
    }
}