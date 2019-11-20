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
            builder.HasOne<TestSession>().WithMany(e => e.TestSessionTestVariants).HasForeignKey(e => e.TestSessionId);
            builder.HasOne<TestVariant>().WithMany().HasForeignKey(e => e.TestVariantId);
        }
    }
}