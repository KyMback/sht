using System;

namespace SHT.Infrastructure.Common
{
    public interface ISafeInjectionResolver
    {
        T Resolve<T>();

        object Resolve(Type type);
    }
}