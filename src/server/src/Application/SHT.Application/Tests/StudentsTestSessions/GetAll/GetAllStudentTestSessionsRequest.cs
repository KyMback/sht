using System.Linq;
using MediatR;
using SHT.Application.Tests.StudentsTestSessions.Contracts;

namespace SHT.Application.Tests.StudentsTestSessions.GetAll
{
    public class GetAllStudentTestSessionsRequest : IRequest<IQueryable<StudentTestSessionDto>>
    {
    }
}