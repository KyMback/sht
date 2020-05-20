using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models;
using SHT.Domain.Models.Common;

namespace SHT.Infrastructure.EF.Configs.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TData> HasSmallMaxLength<TData>(this PropertyBuilder<TData> propertyBuilder)
        {
            propertyBuilder.HasMaxLength(LengthConstants.Small);
            return propertyBuilder;
        }

        public static PropertyBuilder<TData> HasMediumMaxLength<TData>(this PropertyBuilder<TData> propertyBuilder)
        {
            propertyBuilder.HasMaxLength(LengthConstants.Medium);
            return propertyBuilder;
        }

        public static PropertyBuilder<TData> HasLargeMaxLength<TData>(this PropertyBuilder<TData> propertyBuilder)
        {
            propertyBuilder.HasMaxLength(LengthConstants.Large);
            return propertyBuilder;
        }
    }
}