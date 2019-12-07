using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class TestSessionTestVariantConfig : BaseEntityConfig<TestSessionTestVariant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSessionTestVariant> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(LengthConstants.Medium).IsRequired();

            builder.HasIndex(e => new
            {
                e.Name,
                e.TestSessionId,
            }).IsUnique();

            builder
                .HasOne(e => e.TestSession)
                .WithMany(e => e.TestSessionTestVariants)
                .HasForeignKey(e => e.TestSessionId);
            builder
                .HasOne(e => e.TestVariant)
                .WithMany(e => e.TestSessionTestVariants)
                .HasForeignKey(e => e.TestVariantId);
        }
    }
}