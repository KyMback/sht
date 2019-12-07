using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using SHT.Application.Common;
using SHT.Application.Common.Tables;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.Students.GetAll;
using SHT.Domain.Models.Tests.Students;
using SHT.Tests.Integration.Extensions;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures.StudentTests
{
    public class StudentTestSessionCreationTestFixture : BaseTestFixture
    {
        public StudentTestSessionCreationTestFixture(SHTWebApiFactory factory)
            : base(factory)
        {
        }

        /*
        [Theory]
        [AutoData]
        public async Task StudentTestSession_Create_Succeeded(string name)
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
            var response = await StudentGetAuth("api/student-test-session/list".ToRelativeUri());

            // Assert
            response.EnsureSuccessStatusCode();
            var sessionDtos = await FromResponseMessage<TableResult<StudentTestSessionDto>>(response);
            sessionDtos.Should().NotBeNull();
            StudentTestSessionDto session = sessionDtos.Items.SingleOrDefault(e => e.Id == createdEntityResponse.Id);
            session.Should().NotBeNull();
            session.State.Should().Be(StudentTestSessionState.Pending);
            session.Name.Should().BeNull();
        }
        */
    }
}