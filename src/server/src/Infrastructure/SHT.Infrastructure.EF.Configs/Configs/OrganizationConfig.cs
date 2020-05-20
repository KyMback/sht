using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class OrganizationConfig : BaseEntityConfig<Organization>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}