using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    public abstract class BaseEntityConfig<TEntity> : BaseModelConfig<TEntity>
        where TEntity : BaseEntity
    {
        public sealed override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Ignore(e => e.IsNew);
            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}