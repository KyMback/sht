using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.DataAccess.Abstractions.Options;
using SHT.Infrastructure.EF.Configs;

namespace SHT.Infrastructure.DataAccess.EF
{
    public class DefaultDbContext : DbContext, Abstractions.IQueryProvider, IUnitOfWork, IEntitiesTracker, IDataProtectionKeyContext
    {
        private readonly IOptions<DataAccessOptions> _dataAccessOptions;
        private readonly Lazy<IEnumerable<IBeforeCommitHandler>> _beforeCommitHandlers;
        private readonly ILoggerFactory _loggerFactory;

        public DefaultDbContext(
            IOptions<DataAccessOptions> dataAccessOptions,
            Lazy<IEnumerable<IBeforeCommitHandler>> beforeCommitHandlers,
            ILoggerFactory loggerFactory)
        {
            _dataAccessOptions = dataAccessOptions;
            _beforeCommitHandlers = beforeCommitHandlers;
            _loggerFactory = loggerFactory;
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public IQueryable<TEntity> Queryable<TEntity>()
            where TEntity : class => Set<TEntity>().AsQueryable();

        public async Task Commit()
        {
            foreach (var beforeCommitHandler in _beforeCommitHandlers.Value)
            {
                await beforeCommitHandler.Handle(this);
            }

            await SaveChangesAsync();
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

        async Task IUnitOfWork.DeleteRange<TEntity>(IEnumerable<TEntity> entities)
        {
            var uow = (IUnitOfWork)this;
            foreach (var entity in entities)
            {
                await uow.Delete(entity);
            }
        }

        Task<TEntity> IUnitOfWork.GetSingle<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).SingleAsync();
        }

        Task<TData> IUnitOfWork.GetSingle<TEntity, TData>(
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
        {
            return Query(queryParameters, selector).SingleAsync();
        }

        Task<TEntity> IUnitOfWork.GetSingleOrDefault<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).SingleOrDefaultAsync();
        }

        Task<TData> IUnitOfWork.GetSingleOrDefault<TEntity, TData>(
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
        {
            return Query(queryParameters, selector).SingleOrDefaultAsync();
        }

        async Task<IReadOnlyCollection<TEntity>> IUnitOfWork.GetAll<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return await Query(queryParameters).ToArrayAsync();
        }

        public async Task<SearchResult<TEntity>> GetSearchResult<TEntity>(IQueryParameters<TEntity> queryParameters)
            where TEntity : class
        {
            var queryable = Query(queryParameters);
            return new SearchResult<TEntity>(
                await queryable.WithPaging(queryParameters.PagingSettings).ToArrayAsync(),
                await queryable.LongCountAsync());
        }

        public async Task<IReadOnlyCollection<TData>> GetAll<TEntity, TData>(
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class
        {
            return await Query(queryParameters, selector).ToArrayAsync();
        }

        public async Task<SearchResult<TData>> GetSearchResult<TEntity, TData>(
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class
        {
            var queryable = Query(queryParameters);
            return new SearchResult<TData>(
                await queryable.Select(selector).WithPaging(queryParameters.PagingSettings).ToArrayAsync(),
                await queryable.LongCountAsync());
        }

        Task<bool> IUnitOfWork.Any<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).AnyAsync();
        }

        Task<long> IUnitOfWork.Count<TEntity>(IQueryParameters<TEntity> queryParameters)
        {
            return Query(queryParameters).LongCountAsync();
        }

        IEnumerable<TEntity> IEntitiesTracker.GetTrackedEntities<TEntity>(TrackedEntityStates states)
        {
            return ChangeTracker
                .Entries()
                .Where(e => e.Entity is TEntity)
                .Where(e =>
                    (states.HasFlag(TrackedEntityStates.Added) && e.State == EntityState.Added) ||
                    (states.HasFlag(TrackedEntityStates.Modified) && e.State == EntityState.Modified) ||
                    (states.HasFlag(TrackedEntityStates.Deleted) && e.State == EntityState.Deleted))
                .Select(e => (TEntity)e.Entity)
                .ToArray();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableDetailedErrors(_dataAccessOptions.Value.EnableDetailedErrors)
                .UseLazyLoadingProxies()
                .UseNpgsql(_dataAccessOptions.Value.ConnectionsOptions.DefaultConnection);

            if (_dataAccessOptions.Value.EnableLogging)
            {
                optionsBuilder
                    .UseLoggerFactory(_loggerFactory)
                    .EnableSensitiveDataLogging(_dataAccessOptions.Value.EnableSensitiveDataLogging);
            }

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
            return QueryParametersApplier.ApplyQueryParameters(this, queryParameters);
        }

        private IQueryable<TData> Query<TEntity, TData>(
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class
        {
            return QueryParametersApplier.ApplyQueryParameters(this, queryParameters, selector);
        }
    }
}