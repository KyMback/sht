using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHT.Infrastructure.Common.StateMachine.Core
{
    public interface IStateManager<in TEntity>
        where TEntity : class, IHasState
    {
        Task Process(TEntity entity, string trigger, IDictionary<string, string> serializedData = default);

        Task<IReadOnlyCollection<string>> GetAvailableTriggers(TEntity entity);
    }
}