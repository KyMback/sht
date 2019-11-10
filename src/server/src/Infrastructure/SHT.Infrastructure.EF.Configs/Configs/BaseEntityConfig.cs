using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    internal abstract class BaseEntityConfig<TEntity> : BaseModelConfig<TEntity>
        where TEntity : BaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Ignore(e => e.IsNew);
        }
    }
}