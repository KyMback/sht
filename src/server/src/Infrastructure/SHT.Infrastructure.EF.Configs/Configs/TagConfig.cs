using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class TagConfig : BaseEntityConfig<Tag>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();
        }
    }
}