using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Domain.Models.Tests;
using SHT.Tests.Integration.Extensions;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures.Tests
{
    public class TestSessionsCreationTestFixture : BaseTestFixture
    {
        private readonly Uri _endpoint = "api/test-session".ToRelativeUri();

        public TestSessionsCreationTestFixture(SHTWebApiFactory factory)
            : base(factory)
        {
        }

        [Theory]
        [AutoData]
        public async Task TestSession_Creation_Succeeded(string name)
        {
            // Configure
            var data = new TestSessionDetailsDto
            {
                Name = name,
            };

            // Act
            HttpResponseMessage result = await InstructorPostAuth(_endpoint, data);

            // Assert
            result.EnsureSuccessStatusCode();
            var response = await FromResponseMessage<CreatedEntityResponse>(result);
            var testSession = await GetFromDbById<TestSession>(response.Id);
            testSession.Should().NotBeNull();
            testSession.Name.Should().Be(name);
            testSession.State.Should().Be(TestSessionStates.Pending);
        }
    }
}