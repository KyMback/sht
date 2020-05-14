namespace SHT.Infrastructure.Common.StateMachine.Core
{
    public interface IStateConfigurationBuilder<TEntity>
        where TEntity : class, IHasState
    {
        IStateConfiguration<TEntity> Configure();
    }
}