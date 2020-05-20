using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class AccountConfig : BaseEntityConfig<Account>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Account> builder)
        {
            builder.HasOrganization();

            builder.Property(e => e.Email).HasMediumMaxLength().IsRequired();
            builder.Property(e => e.Password).HasMediumMaxLength().IsRequired();
            builder.Property(e => e.SecurityStamp).HasSmallMaxLength().IsRequired();

            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}