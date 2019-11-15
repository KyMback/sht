namespace SHT.Tests.Integration
{
    internal static class AppDefaults
    {
        public static class UserData
        {
            public static string Login => "test";

            public static string Password => "123";

            public static TestAuthorizationCredentials Credentials => new TestAuthorizationCredentials(Login, Password);
        }
    }
}