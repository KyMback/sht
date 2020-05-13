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

        public static bool IsClosedTypeOf(Type closedType, Type openType)
        {
            if (!closedType.IsGenericType)
            {
                return false;
            }

            return closedType.GetGenericTypeDefinition() == openType;
        }

        public static bool IsFinalClassImplementationOfOpenGenericInterface(Type classType, Type openInterfaceType)
        {
            return IsFinalClassImplementation(classType) &&
                   classType.GetInterfaces()
                       .Any(interfaceType => IsClosedTypeOf(interfaceType, openInterfaceType));
        }

        public static bool IsFinalClassImplementation(Type classType)
        {
            return IsCompletedClass(classType) && !classType.IsNested;
        }

        public static bool IsCompletedClass(Type classType)
        {
            return classType.IsClass && !classType.IsAbstract;
        }
    }
}