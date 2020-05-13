using System;
using Microsoft.Extensions.DependencyInjection;
using SHT.Infrastructure.Common;

namespace SHT.BackgroundProcess.Host.Services
{
    internal class BackgroundHostInjectionResolver : ISafeInjectionResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public BackgroundHostInjectionResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public object Resolve(Type type)
        {
            return _serviceProvider.GetService(type);
        }
    }
}
