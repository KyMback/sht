using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Variants;

namespace SHT.Domain.Services
{
    public class TestSessionVariantsQueryParameters : BaseQueryParameters<TestSessionVariant>
    {
        public string Name { get; set; }

        public Guid? TestSessionId { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Name, variant => variant.Name == Name);
            FilterIfHasValue(TestSessionId, variant => variant.TestSessionId == TestSessionId.Value);
        }
    }
}