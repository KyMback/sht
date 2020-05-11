using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Variants
{
    [UsedImplicitly]
    internal class TestVariantConfig : BaseEntityConfig<TestVariant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestVariant> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();

            builder
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}