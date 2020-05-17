using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using SHT.Domain.Models.Users;
using SHT.Domain.Users;
using SHT.Domain.Users.Accounts;
using SHT.Domain.Users.Instructors;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Tests.Unit.Infrastructure.Attributes;
using Xunit;

namespace SHT.Tests.Unit.Users.TestFixtures
{
    public class InstructorAccountServiceTestFixture
    {
        [Theory]
        [AutoMoqData]
        internal async Task Create_GeneralFlow_EmailShouldBeValidatedBeforeCreation(
            string email,
            [Frozen] Mock<IRegistrationValidationService> registrationValidationServiceMock,
            InstructorAccountService instructorAccountService)
        {
            // Arrange
            var data = new InstructorCreationData
            {
                Email = email,
            };

            // Act
            await instructorAccountService.Create(data);

            // Assert
            registrationValidationServiceMock.Verify(
                e => e.TrowsIfEmailIsNotUniq(It.Is<string>(v => v == email)),
                Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task Create_GeneralFlow_InstructorShouldBeCreatedWithCorrectAccount(
            [Frozen] Mock<IUserAccountService> userAccountServiceMock,
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            InstructorAccountService instructorAccountService)
        {
            // Arrange
            var data = new InstructorCreationData();
            var verifiedAccount = new Account();
            userAccountServiceMock.Setup(e => e.Create(It.IsAny<AccountCreationData>())).ReturnsAsync(verifiedAccount);

            // Act
            await instructorAccountService.Create(data);

            // Assert
            unitOfWorkMock.Verify(e => e.Add(It.Is<Instructor>(i => i.Account == verifiedAccount)), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task Create_GeneralFlow_ConfirmationMailShouldBeSentToCorrectAccount(
            [Frozen] Mock<IUserAccountService> userAccountServiceMock,
            InstructorAccountService instructorAccountService)
        {
            // Arrange
            var data = new InstructorCreationData();
            var verifiedAccount = new Account();
            userAccountServiceMock.Setup(e => e.Create(It.IsAny<AccountCreationData>())).ReturnsAsync(verifiedAccount);

            // Act
            await instructorAccountService.Create(data);

            // Assert
            userAccountServiceMock.Verify(e => e.SendEmailConfirmation(verifiedAccount), Times.Once);
        }
    }
}