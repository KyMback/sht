using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Variants.Questions;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Variants
{
    [UsedImplicitly]
    internal class TestSessionVariantChoiceQuestionOptionConfig : BaseEntityConfig<TestSessionVariantChoiceQuestionOption>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSessionVariantChoiceQuestionOption> builder)
        {
            builder.Property(e => e.Text).HasLargeMaxLength().IsRequired();
        }
    }
}