namespace SHT.Tests.Integration
{
    internal class TestAuthorizationCredentials
    {
        public TestAuthorizationCredentials(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}