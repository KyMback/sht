using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests
{
    [UsedImplicitly]
    internal class TestVariantQuestionConfig : BaseEntityConfig<TestVariantQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestVariantQuestion> builder)
        {
            builder.Property(e => e.Text).HasLargeMaxLength().IsRequired();
            builder.Property(e => e.Number).HasSmallMaxLength().IsRequired();

            builder
                .HasOne(e => e.TestVariant)
                .WithMany(e => e.Questions)
                .HasForeignKey(e => e.TestVariantId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}