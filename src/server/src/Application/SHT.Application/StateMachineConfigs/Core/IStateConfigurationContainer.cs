using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateConfigurationContainer<TEntity>
        where TEntity : class, IHasState
    {
        void Configure(IStateConfigurationsBuilder<TEntity> builder);
    }
}