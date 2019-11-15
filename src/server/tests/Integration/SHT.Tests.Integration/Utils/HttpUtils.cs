using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SHT.Tests.Integration.Utils
{
    internal static class HttpUtils
    {
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() },
        };

        public static StringContent ToJsonStringContent(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<TData> FromJson<TData>(HttpResponseMessage message)
        {
            return JsonSerializer.Deserialize<TData>(await message.Content.ReadAsStringAsync(), SerializerOptions);
        }
    }
}