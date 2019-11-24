using System.Text.Json;

namespace SHT.Application.StateMachineConfigs.Core
{
    internal static class StateTransitionContextExtensions
    {
        public static TData DeserializeData<TData>(this IStateTransitionContext context, string key)
        {
            string data = context.SerializedData[key];
            return JsonSerializer.Deserialize<TData>(data);
        }

        public static string DeserializeData(this IStateTransitionContext context, string key)
        {
            return context.SerializedData[key];
        }
    }
}