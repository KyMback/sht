using System;
using System.Linq;
using MediatR;
using SHT.Application.Common;

namespace SHT.Application.Tests.StudentsTestSessions.GetVariants
{
    public class GetStudentTestSessionVariantsRequest : IRequest<IQueryable<Lookup>>
    {
        public GetStudentTestSessionVariantsRequest(Guid studentTestSessionId)
        {
            StudentTestSessionId = studentTestSessionId;
        }

        public Guid StudentTestSessionId { get; set; }
    }
}