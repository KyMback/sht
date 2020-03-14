using System;
using HotChocolate.Types;

namespace SHT.Api.Web.GraphQl.Extensions
{
    public static class EnumTypeDescriptorExtensions
    {
        private const string EnumDefaultFieldName = "value__";

        public static IEnumTypeDescriptor<TEnum> UseNamesAsValues<TEnum>(this IEnumTypeDescriptor<TEnum> descriptor)
        {
            var enumType = typeof(TEnum);
            foreach (var field in typeof(TEnum).GetFields())
            {
                if (field.Name == EnumDefaultFieldName)
                {
                    continue;
                }

                descriptor.Item((TEnum)Enum.ToObject(enumType, field.GetRawConstantValue())).Name(field.Name);
            }

            return descriptor;
        }
    }
}