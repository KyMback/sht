using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateConfigurationBuilder<TEntity>
        where TEntity : class, IHasState
    {
        IStateConfiguration<TEntity> Configure();
    }
}