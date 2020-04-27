using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SHT.Common.Utils
{
    public static class TypeUtils
    {
        public static IReadOnlyDictionary<string, object> GetAllConstFields(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(e => e.Name, e => e.GetValue(null));
        }
    }
}