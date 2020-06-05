using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.StudentsTestSessions.FinalizeStudentsTestSessionsAction.Single
{
    public class FinalizeStudentTestSessionRequest : IRequest
    {
        public FinalizeStudentTestSessionRequest(IReadOnlyCollection<Guid> studentTestSessionIds)
        {
            StudentTestSessionIds = studentTestSessionIds;
        }

        public IReadOnlyCollection<Guid> StudentTestSessionIds { get; set; }
    }
}