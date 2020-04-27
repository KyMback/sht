using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.StudentsTestSessions.GetVariants
{
    public class GetStudentTestSessionVariantsRequest : IRequest<IReadOnlyCollection<string>>
    {
        public GetStudentTestSessionVariantsRequest(Guid studentTestSessionId)
        {
            StudentTestSessionId = studentTestSessionId;
        }

        public Guid StudentTestSessionId { get; set; }
    }
}