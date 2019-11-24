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