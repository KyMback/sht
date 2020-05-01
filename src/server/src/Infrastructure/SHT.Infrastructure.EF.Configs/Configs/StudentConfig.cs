using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class StudentConfig : BaseEntityConfig<Student>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.FirstName).HasSmallMaxLength().IsRequired();
            builder.Property(e => e.LastName).HasSmallMaxLength().IsRequired();
            builder.Property(e => e.Group).HasSmallMaxLength().IsRequired();

            builder
                .HasOne(e => e.Account)
                .WithOne()
                .HasForeignKey<Student>(e => e.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}