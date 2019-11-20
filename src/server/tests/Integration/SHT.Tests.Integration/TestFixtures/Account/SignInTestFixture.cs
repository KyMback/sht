using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using SHT.Application.Users.Accounts.GetContext;
using SHT.Application.Users.Accounts.SignIn;
using SHT.Tests.Integration.Extensions;
using SHT.Tests.Integration.Utils;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures.Account
{
    public class SignInTestFixture : IClassFixture<SHTWebApiFactory>
    {
        private readonly HttpClient _httpClient;

        public SignInTestFixture(SHTWebApiFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task User_SignIn_CorrectCredentials_Success()
        {
            // Act
            var response = await _httpClient.AuthorizeDefaultInstructor();

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await HttpUtils.FromJson<SignInResponse>(response);
            responseData.Succeeded.Should().BeTrue();
        }

        [Theory]
        [AutoData]
        public async Task User_SignIn_IncorrectCredentials_Failed(string login, string pin)
        {
            // Act
            HttpResponseMessage response = await _httpClient.Authorize(login, pin);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await HttpUtils.FromJson<SignInResponse>(response);
            responseData.Succeeded.Should().BeFalse();
        }

        [Fact]
        public async Task AuthenticatedUser_GetContext_Success()
        {
            // Act
            await _httpClient.AuthorizeDefaultInstructor();
            var response = await _httpClient.GetAsync("api/account/context".ToRelativeUri());

            // Assert
            response.EnsureSuccessStatusCode();
            var data = await HttpUtils.FromJson<UserContextDto>(response);

            data.Should().NotBeNull();
            data.Id.Should().NotBeNull();
            data.UserType.Should().NotBeNull();
        }

        [Fact]
        public async Task AnonymousUser_GetContext_Success()
        {
            // Act
            var response = await _httpClient.GetAsync("api/account/context".ToRelativeUri());

            // Assert
            response.EnsureSuccessStatusCode();
            var data = await HttpUtils.FromJson<UserContextDto>(response);

            data.Should().NotBeNull();
            data.Id.Should().BeNull();
            data.UserType.Should().BeNull();
        }
    }
}