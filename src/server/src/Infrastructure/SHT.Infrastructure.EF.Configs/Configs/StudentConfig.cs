using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class StudentConfig : BaseEntityConfig<Student>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.FirstName).HasMaxLength(LengthConstants.Small).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(LengthConstants.Small).IsRequired();
            builder.Property(e => e.Group).HasMaxLength(LengthConstants.Small).IsRequired();

            builder.HasOne(e => e.Account).WithOne().HasForeignKey<Student>(e => e.Id);
        }
    }
}