using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using SHT.Application.Users.Accounts.SignUp;
using SHT.Domain.Models.Users;
using SHT.Tests.Integration.Extensions;
using SHT.Tests.Integration.Utils;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures.Account
{
    public class SignUpTestFixture : IClassFixture<SHTWebApiFactory>
    {
        private readonly SHTWebApiFactory _factory;
        private readonly HttpClient _httpClient;
        private readonly Uri _path = "api/account/signUp".ToRelativeUri();

        public SignUpTestFixture(SHTWebApiFactory factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
        }

        [Theory]
        [InlineAutoData(UserType.Instructor)]
        [InlineAutoData(UserType.Student)]
        public async Task User_SignUp_Succeeded(UserType type, SignUpDataDto data)
        {
            // Configure
            data.UserType = type;
            using var content = HttpUtils.ToJsonStringContent(data);

            // Act
            var response = await _httpClient.PostAsync(_path, content);

            // Assert
            response.EnsureSuccessStatusCode();
            var user = await AppDbUtils.GetSingleOrDefault<User>(_factory, u => u.Login == data.Login);

            user.Should().NotBeNull();
            user.Login.Should().Be(data.Login);
            user.Password.Should().NotBeNullOrWhiteSpace();
            user.UserType.Should().Be(type);
        }
    }
}