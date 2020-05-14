namespace SHT.Infrastructure.Common.StateMachine.Core
{
    public interface IStateConfigurationContainer<TEntity>
        where TEntity : class, IHasState
    {
        void Configure(IStateConfigurationBuilder<TEntity> builder);
    }
}