using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        [ItemNotNull]
        Task<TEntity> Add<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        Task AddRange<TEntity>([ItemNotNull] IEnumerable<TEntity> entities)
            where TEntity : class;

        [ItemNotNull]
        Task<TEntity> Update<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        Task Delete<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        [ItemNotNull]
        Task<TEntity> GetSingle<TEntity>([NotNull] IQueryParameters<TEntity> queryParameters)
            where TEntity : class;

        [ItemNotNull]
        Task<TData> GetSingle<TEntity, TData>(
            [NotNull] IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class;

        [ItemCanBeNull]
        Task<TEntity> GetSingleOrDefault<TEntity>([NotNull] IQueryParameters<TEntity> queryParameters)
            where TEntity : class;

        [ItemCanBeNull]
        Task<TData> GetSingleOrDefault<TEntity, TData>(
            [NotNull] IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class;

        [ItemNotNull]
        Task<IReadOnlyCollection<TEntity>> GetAll<TEntity>([NotNull] IQueryParameters<TEntity> queryParameters)
            where TEntity : class;

        [ItemNotNull]
        Task<IReadOnlyCollection<TData>> GetAll<TEntity, TData>(
            [NotNull] IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class;

        Task<bool> Any<TEntity>([NotNull] IQueryParameters<TEntity> queryParameters)
            where TEntity : class;

        Task<long> Count<TEntity>([NotNull] IQueryParameters<TEntity> queryParameters)
            where TEntity : class;

        Task Commit();
    }
}