using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Application.Tests.TestSessions.Create
{
    public class CreateTestSessionRequest : BaseRequest<TestSessionModificationData, CreatedEntityResponse>
    {
        public CreateTestSessionRequest(TestSessionModificationData data)
            : base(data)
        {
        }
    }
}