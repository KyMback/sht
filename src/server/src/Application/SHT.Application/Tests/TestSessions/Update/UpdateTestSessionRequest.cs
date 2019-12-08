using System;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.Update
{
    public class UpdateTestSessionRequest : BaseRequest<TestSessionDetailsDto>
    {
        public UpdateTestSessionRequest(TestSessionDetailsDto data, Guid id)
            : base(data)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}