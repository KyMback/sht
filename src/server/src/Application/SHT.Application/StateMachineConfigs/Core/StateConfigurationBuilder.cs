using System.Collections.Generic;
using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    internal class StateConfigurationBuilder<TEntity> : IStateConfigurationBuilder<TEntity>
        where TEntity : class, IHasState
    {
        public IList<StateConfiguration<TEntity>> Configurations { get; set; } =
            new List<StateConfiguration<TEntity>>();

        public IStateConfiguration<TEntity> Configure()
        {
            var cfg = new StateConfiguration<TEntity>();
            Configurations.Add(cfg);
            return cfg;
        }
    }
}