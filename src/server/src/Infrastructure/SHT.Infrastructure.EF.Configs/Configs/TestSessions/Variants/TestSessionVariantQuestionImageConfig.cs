using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Variants
{
    [UsedImplicitly]
    internal class TestSessionVariantQuestionImageConfig : BaseModelConfig<TestSessionVariantQuestionImage>
    {
        public override void Configure(EntityTypeBuilder<TestSessionVariantQuestionImage> builder)
        {
            builder.HasKey(e => new
            {
                e.FileId,
                e.TestSessionVariantQuestionId,
            });

            builder.HasOne(e => e.File)
                .WithMany()
                .HasForeignKey(e => e.FileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}