using Autofac;
using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Infrastructure.DataAccess.EF
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DefaultDbContext>()
                .As<IQueryProvider>()
                .As<IUnitOfWork>()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}