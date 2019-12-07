using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionVariantDataDto
    {
        public Guid TestVariantId { get; set; }

        public string Name { get; set; }
    }
}