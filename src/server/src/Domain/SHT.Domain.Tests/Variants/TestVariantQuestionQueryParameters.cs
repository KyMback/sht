using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services.Variants
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