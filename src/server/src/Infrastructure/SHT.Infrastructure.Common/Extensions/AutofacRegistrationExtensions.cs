using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;
using FluentValidation;
using SHT.Infrastructure.Common.AutoMapper;

namespace SHT.Infrastructure.Common.Extensions
{
    public static class AutofacRegistrationExtensions
    {
        public static ContainerBuilder AddAutoMapperTypes(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .As<Profile>()
                .SingleInstance();

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IMemberValueResolver<,,,>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IValueResolver<,,>))
                .AsImplementedInterfaces();

            return builder;
        }

        public static ContainerBuilder UseAutoMapper(this ContainerBuilder builder)
        {
            builder
                .Register(
                    context =>
                        new MapperConfiguration(cfg => cfg.AddProfiles(context.Resolve<IEnumerable<Profile>>())))
                .AsSelf()
                .SingleInstance();

            builder
                .Register(
                    tempContext =>
                    {
                        // HACK: IComponentContext needs to be resolved again as 'tempContext' is only temporary.
                        // See https://kevsoft.net/2016/02/24/automapper-and-autofac-revisited.html and http://stackoverflow.com/a/5386634/718053
                        var ctx = tempContext.Resolve<IComponentContext>();
                        return ctx.Resolve<MapperConfiguration>().CreateMapper();
                    })
                .As<IMapper>()
                .SingleInstance();

            builder.AddSingleAsImplementedInterfaces<AutoMapperInitializer>();

            return builder;
        }

        public static ContainerBuilder RegisterFluentValidators(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces()
                .AsSelf()
                .SingleInstance();

            return builder;
        }

        public static ContainerBuilder UseAfterBuildInitializers(this ContainerBuilder builder)
        {
            builder.RegisterBuildCallback(scope =>
            {
                var inits = scope.Resolve<IEnumerable<IInitializable>>();

                foreach (var initializable in inits)
                {
                    initializable.Init();
                }
            });

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