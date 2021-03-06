using Autofac;
using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.DataAccess.Abstractions.QueryParameters;

namespace SHT.Infrastructure.DataAccess.EF
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .AddAutoMapperTypes(ThisAssembly)
                .RegisterType<DefaultDbContext>()
                .As<IQueryProvider>()
                .As<IUnitOfWork>()
                .As<DbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}