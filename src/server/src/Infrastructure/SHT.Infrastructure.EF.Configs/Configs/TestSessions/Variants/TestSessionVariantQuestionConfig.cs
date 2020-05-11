using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Questions;
using SHT.Domain.Models.TestSessions.Variants.Questions;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Variants
{
    [UsedImplicitly]
    internal class TestSessionVariantQuestionConfig : BaseEntityConfig<TestSessionVariantQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSessionVariantQuestion> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();

            builder.HasOne<QuestionTemplate>()
                .WithMany()
                .HasForeignKey(e => e.SourceQuestionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(e => e.FreeTextQuestion)
                .WithOne()
                .HasForeignKey<TestSessionVariantFreeTextQuestion>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.ChoiceQuestion)
                .WithOne()
                .HasForeignKey<TestSessionVariantChoiceQuestion>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}