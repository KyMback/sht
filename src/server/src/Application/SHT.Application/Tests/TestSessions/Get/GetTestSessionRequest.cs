using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Get
{
    public class GetTestSessionRequest : BaseRequest<Guid, TestSessionDto>
    {
        public GetTestSessionRequest(Guid data)
            : base(data)
        {
        }
    }
}