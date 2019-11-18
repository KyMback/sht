using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using SHT.Application.Core;
using SHT.Application.StateMachineConfigs.TestSessions;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.StateTransition;
using SHT.Tests.Integration.Extensions;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures.Tests
{
    public class TestSessionStateTransitionTestFixture : BaseTestFixture
    {
        private readonly Uri _endpoint = "api/test-session/state".ToRelativeUri();

        public TestSessionStateTransitionTestFixture(SHTWebApiFactory factory)
            : base(factory)
        {
        }

        [Theory]
        [AutoData]
        public async Task TestSession_StartTest_Succeeded(string name)
        {
            // Configure
            var data = new CreateTestSessionDto
            {
                Name = name,
            };

            // Act
            var createdEntityResponse = await FromResponseMessage<CreatedEntityResponse>(
                await PostAuth("api/test-session".ToRelativeUri(), data));
            var response = await PutAuth(_endpoint, new TestSessionStateTransitionRequest
            {
                Trigger = TestSessionTriggers.StartTest,
                TestSessionId = createdEntityResponse.Id,
            });

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [AutoData]
        public async Task TestSession_GetAvailableTriggers_Succeeded(string name)
        {
            // Configure
            var data = new CreateTestSessionDto
            {
                Name = name,
            };

            // Act
            var createdEntityResponse = await FromResponseMessage<CreatedEntityResponse>(
                await PostAuth("api/test-session".ToRelativeUri(), data));
            var response = await GetAuth($"api/test-session/state/{createdEntityResponse.Id}".ToRelativeUri());

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await FromResponseMessage<IReadOnlyCollection<string>>(response);
            responseData.Should().NotBeNullOrEmpty();
        }
    }
}