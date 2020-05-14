using System.Threading.Tasks;

namespace SHT.Infrastructure.Common.StateMachine.Core
{
    public interface IStateTransitionHandler<TEntity>
        where TEntity : class, IHasState
    {
        Task Transit(StateTransitionContext<TEntity> context);
    }
}