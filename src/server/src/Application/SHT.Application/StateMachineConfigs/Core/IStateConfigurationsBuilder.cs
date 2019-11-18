using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateConfigurationsBuilder<TEntity>
        where TEntity : class, IHasState
    {
        IStateConfiguration<TEntity> Configure();
    }
}