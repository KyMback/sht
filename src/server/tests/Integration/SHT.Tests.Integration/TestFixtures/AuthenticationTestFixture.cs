using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using SHT.Application.Users.Accounts.SignIn;
using SHT.Tests.Integration.Extensions;
using SHT.Tests.Integration.Utils;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures
{
    public class AuthenticationTestFixture : IClassFixture<SHTWebApiFactory>
    {
        private readonly HttpClient _httpClient;

        public AuthenticationTestFixture(SHTWebApiFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task User_Authentication_CorrectCredentials_Success()
        {
            // Act
            var response = await _httpClient.AuthorizeDefaultUser();

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await HttpUtils.FromJson<SignInResponse>(response);
            responseData.Succeeded.Should().BeTrue();
        }

        [Theory]
        [AutoData]
        public async Task User_Authentication_IncorrectCredentials_Failed(string login, string pin)
        {
            // Act
            HttpResponseMessage response = await _httpClient.Authorize(login, pin);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await HttpUtils.FromJson<SignInResponse>(response);
            responseData.Succeeded.Should().BeFalse();
        }
    }
}