using System;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Tests
{
    public class TestSessionVariantsQueryParameters : BaseQueryParameters<TestSessionTestVariant>
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