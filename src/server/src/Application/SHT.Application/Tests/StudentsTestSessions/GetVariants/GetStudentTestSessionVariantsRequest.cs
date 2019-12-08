using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.StudentsTestSessions.GetVariants
{
    public class GetStudentTestSessionVariantsRequest : IRequest<IEnumerable<string>>
    {
        public GetStudentTestSessionVariantsRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}