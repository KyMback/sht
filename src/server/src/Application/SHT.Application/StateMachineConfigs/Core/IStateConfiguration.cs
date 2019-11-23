using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateConfiguration<TEntity>
        where TEntity : class, IHasState
    {
        IStateConfiguration<TEntity> From(string state);

        IStateConfiguration<TEntity> WithTrigger(string trigger);

        IStateConfiguration<TEntity> To(string state);

        IStateConfiguration<TEntity> WithGuard<TGuard>()
            where TGuard : IStateTransitionGuard<TEntity>;

        IStateConfiguration<TEntity> Use<THandler>()
            where THandler : IStateTransitionHandler<TEntity>;
    }
}