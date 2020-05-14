using System.Text.Json;

namespace SHT.Infrastructure.Common.StateMachine.Core
{
    internal static class StateTransitionContextExtensions
    {
        public static TData DeserializeData<TData>(this IStateTransitionContext context, string key)
        {
            string data = context.SerializedData[key];
            return JsonSerializer.Deserialize<TData>(data);
        }
    }
}