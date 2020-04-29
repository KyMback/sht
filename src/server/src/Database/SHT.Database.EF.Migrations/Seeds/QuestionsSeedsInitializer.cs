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
        private static readonly IReadOnlyCollection<QuestionTemplate> TestVariants = new[]
        {
            new QuestionTemplate
            {
                Id = QuestionsDefaults.FreeTextQuestion.Id,
                Text = QuestionsDefaults.FreeTextQuestion.Text,
                Type = QuestionType.FreeText,
                CreatedById = UsersDefaults.Instructor.Id
            },
        };

        public Task ApplySeeds(DbContext context)
        {
            return context.AddRangeAsync(TestVariants);
        }
    }
}