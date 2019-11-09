using System;
using System.Reflection;
using Autofac;
using FluentValidation;

namespace SHT.Infrastructure.Common.Extensions
{
    public static class AutofacRegistrationExtensions
    {
        public static ContainerBuilder RegisterFluentValidators(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces()
                .SingleInstance();

            return builder;
        }

        public static ContainerBuilder AddScoped<T>(this ContainerBuilder builder)
        {
            builder.RegisterType<T>().InstancePerLifetimeScope();
            return builder;
        }

        public static ContainerBuilder AddScoped<TAs, TService>(this ContainerBuilder builder)
        {
            builder.RegisterType<TService>().As<TAs>().InstancePerLifetimeScope();
            return builder;
        }

        public static ContainerBuilder AddScoped(this ContainerBuilder builder, Type serviceType, Type registeringType)
        {
            builder.RegisterType(serviceType).As(registeringType).InstancePerLifetimeScope();
            return builder;
        }

        public static ContainerBuilder AddScopedAsImplementedInterfaces<TService>(this ContainerBuilder builder)
        {
            builder.RegisterType<TService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            return builder;
        }

        public static ContainerBuilder AddGenericScopedAsImplementedInterfaces(
            this ContainerBuilder builder,
            Type genericType)
        {
            builder.RegisterGeneric(genericType).AsImplementedInterfaces().InstancePerLifetimeScope();
            return builder;
        }

        public static ContainerBuilder AddSingle<TAs, TService>(this ContainerBuilder builder)
        {
            builder.RegisterType<TService>().As<TAs>().SingleInstance();
            return builder;
        }

        public static ContainerBuilder AddSingleAsImplementedInterfaces<TService>(this ContainerBuilder builder)
        {
            builder.RegisterType<TService>().AsImplementedInterfaces().SingleInstance();
            return builder;
        }

        public static ContainerBuilder AddTypeAssembly<T>(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(typeof(T).Assembly);
            return builder;
        }
    }
}