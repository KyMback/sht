using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Services.Student;
using SHT.Domain.Services.Student.Questions;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Tests.Unit.Infrastructure.Attributes;
using SHT.Tests.Unit.Infrastructure.Extensions;
using Xunit;

namespace SHT.Tests.Unit.TestSessions.TestFixtures
{
    public class StudentQuestionValidationServiceTestFixture
    {
        [Theory]
        [AutoMoqData]
        internal async Task ThrowIfCannotAnswer_IncorrectTestSessionState_ThrowsException(
            Guid studentTestSessionId,
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            StudentQuestionValidationService studentQuestionValidationService)
        {
            // Arrange
            unitOfWorkMock.Setup(e => e.Any(It.IsAny<StudentTestSessionQueryParameters>())).ReturnsAsync(false);

            // Act
            Func<Task> action = () => studentQuestionValidationService.ThrowIfCannotAnswer(studentTestSessionId);

            // Assert
            await action.Should().ThrowWithCode<CodedException>(ErrorCode.StudentTestSessionEnded);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ThrowIfCannotAnswer_CorrectTestSessionState_Success(
            Guid studentTestSessionId,
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            StudentQuestionValidationService studentQuestionValidationService)
        {
            // Arrange
            unitOfWorkMock.Setup(e => e.Any(It.IsAny<StudentTestSessionQueryParameters>())).ReturnsAsync(true);

            // Act
            Func<Task> action = () => studentQuestionValidationService.ThrowIfCannotAnswer(studentTestSessionId);

            // Assert
            await action.Should().NotThrowAsync<CodedException>();
        }
    }
}