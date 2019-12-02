using System.Threading.Tasks;
using JetBrains.Annotations;
using SHT.Domain.Models.Common;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Common
{
    [UsedImplicitly]
    internal class CreatedAtBeforeCommitHandler : IBeforeCommitHandler
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreatedAtBeforeCommitHandler(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public Task Handle(IEntitiesTracker entitiesTracker)
        {
            foreach (var entity in entitiesTracker.GetTrackedEntities<IHasCreatedAt>(TrackedEntityStates.Added))
            {
                entity.CreatedAt = _dateTimeProvider.UtcNow;
            }

            return Task.CompletedTask;
        }
    }
}