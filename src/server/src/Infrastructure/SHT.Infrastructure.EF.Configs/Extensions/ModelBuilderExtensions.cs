using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoreLinq.Extensions;

namespace SHT.Infrastructure.EF.Configs.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static ModelBuilder UseDefaultDeleteBehavior(
            this ModelBuilder builder,
            DeleteBehavior behavior)
        {
            builder.Model.GetEntityTypes()
                .SelectMany(type => type.GetForeignKeys())
                .Where(fk => !fk.IsOwnership)
                .ForEach(fk => fk.DeleteBehavior = behavior);

            return builder;
        }
    }
}