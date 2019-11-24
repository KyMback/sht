using System.Collections.Generic;

namespace SHT.Application.StateMachineConfigs.Core
{
    public interface IStateTransitionContext
    {
        string SourceState { get; set; }

        string TargetState { get; set; }

        string Trigger { get; set; }

        IDictionary<string, string> SerializedData { get; set; }
    }
}