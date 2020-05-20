using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Common;

namespace SHT.Infrastructure.EF.Configs.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> HasOrganization<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IHasOrganization
        {
            builder.HasOne(e => e.Organization)
                .WithMany()
                .HasForeignKey(e => e.OrganizationId)
                .OnDelete(DeleteBehavior.ClientCascade);

            return builder;
        }
    }
}