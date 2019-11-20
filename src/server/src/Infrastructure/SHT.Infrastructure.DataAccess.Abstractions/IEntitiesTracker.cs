using System.Collections.Generic;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public interface IEntitiesTracker
    {
        IEnumerable<TEntity> GetTrackedEntities<TEntity>(TrackedEntityStates states)
            where TEntity : class;
    }
}