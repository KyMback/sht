using System.Threading.Tasks;
using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateTransitionHandler<TEntity>
        where TEntity : class, IHasState
    {
        Task Transit(StateTransitionContext<TEntity> context);
    }
}