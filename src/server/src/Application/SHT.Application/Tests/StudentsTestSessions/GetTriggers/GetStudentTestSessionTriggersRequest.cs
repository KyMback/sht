using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.StudentsTestSessions.GetTriggers
{
    public class GetStudentTestSessionTriggersRequest : IRequest<IReadOnlyCollection<string>>
    {
        public GetStudentTestSessionTriggersRequest(Guid testSessionId)
        {
            TestSessionId = testSessionId;
        }

        public Guid TestSessionId { get; set; }
    }
}