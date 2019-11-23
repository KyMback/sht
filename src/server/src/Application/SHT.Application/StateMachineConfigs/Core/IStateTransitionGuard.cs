using System.Threading.Tasks;
using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateTransitionGuard<in TEntity>
        where TEntity : class, IHasState
    {
        Task<bool> Check(TEntity entity);
    }
}