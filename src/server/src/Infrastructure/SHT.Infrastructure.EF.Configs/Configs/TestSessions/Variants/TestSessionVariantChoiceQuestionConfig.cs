using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Variants.Questions;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Variants
{
    [UsedImplicitly]
    internal class TestSessionVariantChoiceQuestionConfig : BaseEntityConfig<TestSessionVariantChoiceQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSessionVariantChoiceQuestion> builder)
        {
            builder.Property(e => e.QuestionText).HasLargeMaxLength().IsRequired();
            builder.HasMany(e => e.Options)
                .WithOne()
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}