using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.Create
{
    public class CreateTestSessionRequest : BaseRequest<TestSessionModificationDataDto, CreatedEntityResponse>
    {
        public CreateTestSessionRequest(TestSessionModificationDataDto data)
            : base(data)
        {
        }
    }
}