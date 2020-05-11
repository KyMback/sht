using System;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Application.Tests.TestSessions.Update
{
    public class UpdateTestSessionRequest : IRequest
    {
        public UpdateTestSessionRequest(TestSessionModificationData data, Guid testSessionId)
        {
            Data = data;
            TestSessionId = testSessionId;
        }

        public Guid TestSessionId { get; set; }

        public TestSessionModificationData Data { get; set; }
    }
}