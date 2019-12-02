using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class AccountConfig : BaseEntityConfig<Account>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Account> builder)
        {
            builder.Property(e => e.Email).HasMaxLength(LengthConstants.Medium).IsRequired();
            builder.Property(e => e.Password).HasMaxLength(LengthConstants.Medium).IsRequired();

            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}