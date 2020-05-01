using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services
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