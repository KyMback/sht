using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services.Variants
{
    public class TestVariantQueryParameters : BaseQueryParameters<TestVariant>
    {
        public Guid? Id { get; set; }

        public string Number { get; set; }

        public bool IncludeQuestions { get; set; }

        public Guid? CreatedById { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, variant => variant.Id == Id.Value);
            FilterIfHasValue(Number, variant => variant.Name == Number);
            FilterIfHasValue(CreatedById, variant => variant.CreatedById == CreatedById.Value);
        }

        protected override void AddIncluded()
        {
            IncludeIf(IncludeQuestions, variant => variant.Questions);
        }
    }
}