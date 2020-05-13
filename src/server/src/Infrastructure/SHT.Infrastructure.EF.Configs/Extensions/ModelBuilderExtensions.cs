using Microsoft.EntityFrameworkCore;
using MoreLinq.Extensions;

namespace SHT.Infrastructure.EF.Configs.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static ModelBuilder UseDefaultSchema(
            this ModelBuilder builder,
            string schema)
        {
            builder.Model.GetEntityTypes().ForEach(type => type.SetSchema(schema));

            return builder;
        }
    }
}