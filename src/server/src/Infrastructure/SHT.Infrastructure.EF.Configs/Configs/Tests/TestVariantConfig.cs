using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests
{
    [UsedImplicitly]
    internal class TestVariantConfig : BaseEntityConfig<TestVariant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestVariant> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(LengthConstants.Medium).IsRequired();

            builder
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}