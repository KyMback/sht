using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Variants.Questions;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Variants
{
    [UsedImplicitly]
    internal class TestSessionVariantFreeTextQuestionConfig : BaseEntityConfig<TestSessionVariantFreeTextQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSessionVariantFreeTextQuestion> builder)
        {
            builder.Property(e => e.QuestionText).HasLargeMaxLength().IsRequired();
        }
    }
}