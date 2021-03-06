using System.Net.Http;
using System.Threading.Tasks;
using SHT.Tests.Integration.Utils;

namespace SHT.Tests.Integration.Extensions
{
    internal static class AppHttpClientExtensions
    {
        public static Task<HttpResponseMessage> Authorize(this HttpClient client, string login, string password)
        {
            return client.Authorize(new TestAuthorizationCredentials(login, password));
        }

        public static Task<HttpResponseMessage> AuthorizeDefaultInstructor(this HttpClient client)
        {
            return client.Authorize(AppDefaults.InstructorUserData.Credentials);
        }

        public static Task<HttpResponseMessage> AuthorizeDefaultStudent(this HttpClient client)
        {
            return client.Authorize(AppDefaults.StudentUserData.Credentials);
        }

        private static async Task<HttpResponseMessage> Authorize(
            this HttpClient client,
            TestAuthorizationCredentials credentials)
        {
            using var data = HttpUtils.ToJsonStringContent(credentials);
            return await client.PostAsync("/api/account/signIn".ToRelativeUri(), data);
        }
    }
}