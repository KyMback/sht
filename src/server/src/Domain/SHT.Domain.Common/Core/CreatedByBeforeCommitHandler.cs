using System.Threading.Tasks;
using JetBrains.Annotations;
using SHT.Domain.Models.Common;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Common.Core
{
    [UsedImplicitly]
    internal class CreatedByBeforeCommitHandler : IBeforeCommitHandler
    {
        private readonly IExecutionContextService _executionContextService;

        public CreatedByBeforeCommitHandler(IExecutionContextService executionContextService)
        {
            _executionContextService = executionContextService;
        }

        public Task Handle(IEntitiesTracker entitiesTracker)
        {
            var currentUserId = _executionContextService.GetCurrentUserId();
            foreach (var entity in entitiesTracker.GetTrackedEntities<IHasCreatedBy>(TrackedEntityStates.Added))
            {
                entity.CreatedById = currentUserId;
            }

            return Task.CompletedTask;
        }
    }
}