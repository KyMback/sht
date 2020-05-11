using System.Linq;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.GetAll
{
    public class GetAllTestSessionsRequest : IRequest<IQueryable<TestSessionDto>>
    {
    }
}