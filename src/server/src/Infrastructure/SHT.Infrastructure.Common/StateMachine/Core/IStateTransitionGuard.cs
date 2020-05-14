using System.Threading.Tasks;

namespace SHT.Infrastructure.Common.StateMachine.Core
{
    public interface IStateTransitionGuard<in TEntity>
        where TEntity : class, IHasState
    {
        Task<bool> Check(TEntity entity);
    }
}