using System;
using MediatR;

namespace SHT.Application.Tests.StudentsTestSessions.Get
{
    public class GetStudentTestSessionRequest : IRequest<StudentTestSessionDto>
    {
        public GetStudentTestSessionRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}