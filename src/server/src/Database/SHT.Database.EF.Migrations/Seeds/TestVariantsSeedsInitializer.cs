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
                CreatedById = UsersDefaults.Instructor.Id,
                Questions = new List<TestVariantQuestion>
                {
                    new TestVariantQuestion
                    {
                        Number = QuestionsDefaults.FreeTextQuestion.Number,
                        Text = QuestionsDefaults.FreeTextQuestion.Text,
                        Type = QuestionType.FreeText,
                    }
                }
            },
        };

        public Task ApplySeeds(DbContext context)
        {
            return context.AddRangeAsync(TestVariants);
        }
    }
}