using System.Collections.Generic;
using System.Threading.Tasks;
using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateManager<in TEntity>
        where TEntity : class, IHasState
    {
        Task Process(TEntity entity, string trigger, IDictionary<string, string> serializedData = default);

        Task<IReadOnlyCollection<string>> GetAvailableTriggers(TEntity entity);
    }
}