using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Database.Defaults;
using SHT.Database.EF.Migrations.Seeds.Core;
using SHT.Domain.Models.Tests;

namespace SHT.Database.EF.Migrations.Seeds
{
    internal class QuestionsSeedsInitializer : ISeedsInitializer
    {
        private static readonly IReadOnlyCollection<Question> TestVariants = new[]
        {
            new Question
            {
                Id = QuestionsDefaults.FreeTextQuestion.Id,
                Number = QuestionsDefaults.FreeTextQuestion.Number,
                Text = QuestionsDefaults.FreeTextQuestion.Text,
                Type = QuestionType.FreeText,
                TestVariantId = QuestionsDefaults.FreeTextQuestion.TestVariantId,
            },
        };

        public Task ApplySeeds(DbContext context)
        {
            return context.AddRangeAsync(TestVariants);
        }
    }
}