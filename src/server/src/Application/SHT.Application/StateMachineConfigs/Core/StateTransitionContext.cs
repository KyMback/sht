using System.Collections.Generic;
using SHT.Domain.Models.Common;

namespace SHT.Application.StateMachineConfigs.Core
{
    public class StateTransitionContext<TEntity> : IStateTransitionContext
        where TEntity : class, IHasState
    {
        public TEntity Entity { get; set; }

        public string SourceState { get; set; }

        public string TargetState { get; set; }

        public string Trigger { get; set; }

        public IDictionary<string, string> SerializedData { get; set; }
    }
}