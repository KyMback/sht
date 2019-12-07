using MediatR;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.Create
{
    public class CreateTestSessionRequest : IRequest<CreatedEntityResponse>
    {
        public CreateTestSessionRequest(CreateTestSessionDto data)
        {
            Data = data;
        }

        public CreateTestSessionDto Data { get; set; }
    }
}