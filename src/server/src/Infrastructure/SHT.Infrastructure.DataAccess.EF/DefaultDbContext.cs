using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.Common.Options;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.EF.Configs;

namespace SHT.Infrastructure.DataAccess.EF
{
    public class DefaultDbContext : DbContext, Abstractions.IQueryProvider, IUnitOfWork
    {
        private readonly ConnectionsOptions _connectionsOptions;

        public DefaultDbContext(ConnectionsOptions connectionsOptions)
        {
            _connectionsOptions = connectionsOptions;
        }

        public IQueryable<TEntity> Queryable<TEntity>()
            where TEntity : class =>
            Set<TEntity>().AsQueryable();

        public Task Commit()
        {
            return SaveChangesAsync();
        }

        async Task<TEntity> IUnitOfWork.Add<TEntity>(TEntity entity)
        {
            var result = await AddAsync(entity);
            return result.Entity;
        }

        Task IUnitOfWork.AddRange<TEntity>(IEnumerable<TEntity> entities)
        {
            return AddRangeAsync(entities);
        }

        Task<TEntity> IUnitOfWork.Update<TEntity>(TEntity entity)
        {
            return Task.FromResult(entity);
        }

        Task IUnitOfWork.Delete<TEntity>(TEntity entity)
        {
            Remove(entity);
            return Task.CompletedTask;
        }

        Task<TEntity> IUnitOfWork.GetSingle<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).SingleAsync();
        }

        Task<TData> IUnitOfWork.GetSingle<TEntity, TData>(
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
        {
            return Query(queryParameters).Select(selector).SingleAsync();
        }

        Task<TEntity> IUnitOfWork.GetSingleOrDefault<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).SingleOrDefaultAsync();
        }

        Task<TData> IUnitOfWork.GetSingleOrDefault<TEntity, TData>(
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
        {
            return Query(queryParameters).Select(selector).SingleOrDefaultAsync();
        }

        async Task<IReadOnlyCollection<TEntity>> IUnitOfWork.GetAll<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return await Query(queryParameters).ToArrayAsync();
        }

        Task<bool> IUnitOfWork.Any<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).AnyAsync();
        }

        Task<long> IUnitOfWork.Count<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).LongCountAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(_connectionsOptions.DefaultConnection);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelsConfigsApplier.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private IQueryable<TEntity> Query<TEntity>(IQueryParameters<TEntity> queryParameters)
            where TEntity : class
        {
            var queryable = queryParameters.ToQuery(this);
            return queryParameters.IsReadOnly ? queryable.AsNoTracking() : queryable.AsTracking();
        }
    }
}