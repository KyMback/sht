using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Database.Defaults;
using SHT.Database.EF.Migrations.Seeds.Core;
using SHT.Domain.Models.Tests;

namespace SHT.Database.EF.Migrations.Seeds
{
    internal class TestVariantsSeedsInitializer : ISeedsInitializer
    {
        private static readonly IReadOnlyCollection<TestVariant> TestVariants = new[]
        {
            new TestVariant
            {
                Id = TestVariantsDefaults.TestVariantWithFreeTextQuestion.Id,
                Name = TestVariantsDefaults.TestVariantWithFreeTextQuestion.Name,
            },
        };

        public Task ApplySeeds(DbContext context)
        {
            return context.AddRangeAsync(TestVariants);
        }
    }
}