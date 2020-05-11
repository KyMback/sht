using System;
using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit
{
    [ApiDataContract]
    public class TestSessionVariantModificationData
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public bool IsRandomOrder { get; set; }

        public IReadOnlyCollection<TestSessionVariantQuestionModificationData> Questions { get; set; }
    }
}