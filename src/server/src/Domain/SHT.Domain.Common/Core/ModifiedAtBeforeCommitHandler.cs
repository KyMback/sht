using System.Threading.Tasks;
using JetBrains.Annotations;
using SHT.Domain.Models.Common;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Common.Core
{
    [UsedImplicitly]
    internal class ModifiedAtBeforeCommitHandler : IBeforeCommitHandler
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ModifiedAtBeforeCommitHandler(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public Task Handle(IEntitiesTracker entitiesTracker)
        {
            var utcNow = _dateTimeProvider.UtcNow;
            foreach (var entity in entitiesTracker.GetTrackedEntities<IHasModifiedAt>(TrackedEntityStates.Added | TrackedEntityStates.Modified))
            {
                entity.ModifiedAt = utcNow;
            }

            return Task.CompletedTask;
        }
    }
}