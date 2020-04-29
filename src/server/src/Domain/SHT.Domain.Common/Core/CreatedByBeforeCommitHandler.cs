using System.Threading.Tasks;
using JetBrains.Annotations;
using SHT.Domain.Models.Common;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Common.Core
{
    [UsedImplicitly]
    internal class CreatedByBeforeCommitHandler : IBeforeCommitHandler
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public CreatedByBeforeCommitHandler(IExecutionContextAccessor executionContextAccessor)
        {
            _executionContextAccessor = executionContextAccessor;
        }

        public Task Handle(IEntitiesTracker entitiesTracker)
        {
            var currentUserId = _executionContextAccessor.GetCurrentUserId();
            foreach (var entity in entitiesTracker.GetTrackedEntities<IHasCreatedBy>(TrackedEntityStates.Added))
            {
                entity.CreatedById = currentUserId;
            }

            return Task.CompletedTask;
        }
    }
}