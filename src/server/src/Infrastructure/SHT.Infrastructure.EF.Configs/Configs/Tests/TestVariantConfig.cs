using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests
{
    [UsedImplicitly]
    internal class TestVariantConfig : BaseEntityConfig<TestVariant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestVariant> builder)
        {
        }
    }
}