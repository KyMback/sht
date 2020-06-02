using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Files;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Files
{
    public class FileConfig : BaseEntityConfig<File>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<File> builder)
        {
            builder.Property(x => x.Reference).HasMediumMaxLength().IsRequired();
            builder.Property(x => x.ContentType).HasMediumMaxLength().IsRequired();
            builder.Property(x => x.OriginalName).HasMediumMaxLength().IsRequired();

            builder.HasIndex(x => x.Reference).IsUnique();

            builder.HasOne<Account>()
                .WithMany()
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}