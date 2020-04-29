using System.Threading.Tasks;
using JetBrains.Annotations;
using SHT.Domain.Models.Common;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Common.Core
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
            var utcNow = _dateTimeProvider.UtcNow;
            foreach (var entity in entitiesTracker.GetTrackedEntities<IHasCreatedAt>(TrackedEntityStates.Added))
            {
                entity.CreatedAt = utcNow;
            }

            return Task.CompletedTask;
        }
    }
}