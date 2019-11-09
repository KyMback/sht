using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SHT.Infrastructure.EF.Configs
{
    public abstract class BaseModelConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);
    }
}