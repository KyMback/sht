using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.TestSessions.GetTriggers
{
    public class GetTestSessionTriggersRequest : IRequest<IReadOnlyCollection<string>>
    {
        public GetTestSessionTriggersRequest(Guid testSessionId)
        {
            TestSessionId = testSessionId;
        }

        public Guid TestSessionId { get; set; }
    }
}