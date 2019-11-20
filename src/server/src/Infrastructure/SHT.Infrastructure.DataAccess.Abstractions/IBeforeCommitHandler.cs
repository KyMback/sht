using System.Threading.Tasks;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public interface IBeforeCommitHandler
    {
        Task Handle(IEntitiesTracker entitiesTracker);
    }
}