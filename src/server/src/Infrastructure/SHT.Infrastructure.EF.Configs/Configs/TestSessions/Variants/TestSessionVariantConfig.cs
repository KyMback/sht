using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Variants;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Variants
{
    [UsedImplicitly]
    internal class TestSessionVariantConfig : BaseEntityConfig<TestSessionVariant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSessionVariant> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();

            builder.HasIndex(e => new
            {
                e.Name,
                e.TestSessionId,
            }).IsUnique();

            builder
                .HasMany(e => e.Questions)
                .WithOne(e => e.TestSessionVariant)
                .HasForeignKey(e => e.TestSessionVariantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.TestSession)
                .WithMany(e => e.Variants)
                .HasForeignKey(e => e.TestSessionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}