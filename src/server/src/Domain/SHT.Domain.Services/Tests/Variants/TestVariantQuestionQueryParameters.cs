using System;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Tests.Variants
{
    public class TestVariantQuestionQueryParameters : BaseQueryParameters<TestVariantQuestion>
    {
        public Guid? TestVariantId { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(TestVariantId, question => question.TestVariantId == TestVariantId.Value);
        }
    }
}