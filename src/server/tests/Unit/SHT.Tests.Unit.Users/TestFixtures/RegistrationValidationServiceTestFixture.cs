using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Users;
using SHT.Domain.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Tests.Unit.Infrastructure.Attributes;
using SHT.Tests.Unit.Infrastructure.Extensions;
using Xunit;

namespace SHT.Tests.Unit.Users.TestFixtures
{
    public class RegistrationValidationServiceTestFixture
    {
        [Theory]
        [AutoMoqData]
        internal async Task TrowsIfEmailIsNotUniq_EmailIsNotUniq_ThrowsCorrectException(
            string email,
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            RegistrationValidationService registrationValidationService)
        {
            // Arrange
            unitOfWorkMock
                .Setup(e => e.Any(It.Is<AccountQueryParameters>(q => q.NormalizedEmail == email)))
                .ReturnsAsync(true);

            // Act
            Func<Task> action = async () => await registrationValidationService.TrowsIfEmailIsNotUniq(email);

            // Assert
            await action.Should().ThrowWithCode<CodedException>(ErrorCode.LoginIsNotUniq);
        }

        [Theory]
        [AutoMoqData]
        internal async Task TrowsIfEmailIsNotUniq_EmailIsUniq_Success(
            string email,
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            RegistrationValidationService registrationValidationService)
        {
            // Arrange
            unitOfWorkMock
                .Setup(e => e.Any(It.Is<AccountQueryParameters>(q => q.NormalizedEmail == email)))
                .ReturnsAsync(false);

            // Act
            Func<Task> action = async () => await registrationValidationService.TrowsIfEmailIsNotUniq(email);

            // Assert
            await action.Should().NotThrowAsync();
        }
    }
}