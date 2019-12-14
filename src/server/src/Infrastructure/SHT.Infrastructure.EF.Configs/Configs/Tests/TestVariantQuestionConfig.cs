using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests
{
    [UsedImplicitly]
    internal class TestVariantQuestionConfig : BaseEntityConfig<TestVariantQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestVariantQuestion> builder)
        {
            builder.Property(e => e.Text).HasMaxLength(LengthConstants.Large).IsRequired();
            builder.Property(e => e.Number).HasMaxLength(LengthConstants.Small).IsRequired();

            builder.HasOne(e => e.TestVariant).WithMany(e => e.Questions).HasForeignKey(e => e.TestVariantId);
        }
    }
}