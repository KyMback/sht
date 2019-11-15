using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class UserConfig : BaseEntityConfig<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Login).HasMaxLength(LengthConstants.MediumLength).IsRequired();
            builder.Property(e => e.Password).HasMaxLength(LengthConstants.MediumLength).IsRequired();

            builder.HasIndex(e => e.Login).IsUnique();
        }
    }
}