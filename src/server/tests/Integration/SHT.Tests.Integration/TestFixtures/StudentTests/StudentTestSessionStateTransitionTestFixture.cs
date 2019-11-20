using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using SHT.Application.Core;
using SHT.Application.StateMachineConfigs.StudentTestSessions;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.Students.GetAll;
using SHT.Application.Tests.TestSessions.Students.StateTransition;
using SHT.Domain.Models.Tests.Students;
using SHT.Tests.Integration.Extensions;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures.StudentTests
{
    public class StudentTestSessionStateTransitionTestFixture : BaseTestFixture
    {
        public StudentTestSessionStateTransitionTestFixture(SHTWebApiFactory factory)
            : base(factory)
        {
        }

        [Theory]
        [AutoData]
        public async Task StudentTestSession_StartTest_Succeeded(string name)
        {
            // Configure
            var data = new CreateTestSessionDto
            {
                Name = name,
                StudentsIds = new[] { AppDefaults.StudentUserData.Id },
            };

            // Act
            CreatedEntityResponse createdEntityResponse = await FromResponseMessage<CreatedEntityResponse>(
                await InstructorPostAuth("api/test-session".ToRelativeUri(), data));
            IReadOnlyCollection<StudentTestSessionDto> sessions =
                await FromResponseMessage<IReadOnlyCollection<StudentTestSessionDto>>(
                    await StudentGetAuth("api/student-test-session/list".ToRelativeUri()));
            StudentTestSessionDto session = sessions.Single(e => e.TestSessionId == createdEntityResponse.Id);
            var response = await InstructorPutAuth(
                "api/student-test-session/state".ToRelativeUri(),
                new StudentTestSessionStateTransitionRequest
                {
                    StudentTestSessionId = session.Id,
                    Trigger = StudentTestSessionTriggers.StartTest,
                });

            // Assert
            response.EnsureSuccessStatusCode();
            var testSession = await GetFromDbById<StudentTestSession>(session.Id);
            testSession.Should().NotBeNull();
            testSession.State.Should().Be(StudentTestSessionState.Started);
        }
    }
}