using System;
using System.Linq;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Tests.Variants
{
    public class TestVariantQueryParameters : BaseQueryParameters<TestVariant>
    {
        public Guid? TestSessionId { get; set; }

        public string Number { get; set; }

        public bool IncludeQuestions { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(TestSessionId, variant => variant.TestSessionTestVariants.Any(e => e.TestSessionId == TestSessionId.Value));
            FilterIfHasValue(Number, variant => variant.Name == Number);
        }

        protected override void AddIncluded()
        {
            IncludeIf(IncludeQuestions, variant => variant.Questions);
        }
    }
}