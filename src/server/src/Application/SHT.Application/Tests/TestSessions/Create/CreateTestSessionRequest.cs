using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.Create
{
    public class CreateTestSessionRequest : BaseRequest<TestSessionDetailsDto, CreatedEntityResponse>
    {
        public CreateTestSessionRequest(TestSessionDetailsDto data)
            : base(data)
        {
        }
    }
}