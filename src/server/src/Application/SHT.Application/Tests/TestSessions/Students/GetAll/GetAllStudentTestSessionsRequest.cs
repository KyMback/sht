using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.TestSessions.Students.GetAll
{
    public class GetAllStudentTestSessionsRequest : IRequest<IReadOnlyCollection<StudentTestSessionDto>>
    {
        public string State { get; set; }
    }
}