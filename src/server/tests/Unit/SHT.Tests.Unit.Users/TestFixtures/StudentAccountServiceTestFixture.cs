using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using SHT.Domain.Models.Users;
using SHT.Domain.Users;
using SHT.Domain.Users.Accounts;
using SHT.Domain.Users.Students;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Tests.Unit.Infrastructure.Attributes;
using Xunit;

namespace SHT.Tests.Unit.Users.TestFixtures
{
    public class StudentAccountServiceTestFixture
    {
        [Theory]
        [AutoMoqData]
        internal async Task Create_GeneralFlow_EmailShouldBeValidatedBeforeCreation(
            string email,
            [Frozen] Mock<IRegistrationValidationService> registrationValidationServiceMock,
            StudentAccountService studentAccountService)
        {
            // Arrange
            var data = new StudentCreationData
            {
                Email = email,
            };

            // Act
            await studentAccountService.Create(data);

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
            StudentAccountService studentAccountService)
        {
            // Arrange
            var data = new StudentCreationData();
            var verifiedAccount = new Account();
            userAccountServiceMock.Setup(e => e.Create(It.IsAny<AccountCreationData>())).ReturnsAsync(verifiedAccount);

            // Act
            await studentAccountService.Create(data);

            // Assert
            unitOfWorkMock.Verify(e => e.Add(It.Is<Student>(i => i.Account == verifiedAccount)), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task Create_GeneralFlow_EmailShouldBeSentIntoCorrectAccount(
            [Frozen] Mock<IUserAccountService> userAccountServiceMock,
            StudentAccountService studentAccountService)
        {
            // Arrange
            var data = new StudentCreationData();
            var verifiedAccount = new Account();
            userAccountServiceMock.Setup(e => e.Create(It.IsAny<AccountCreationData>())).ReturnsAsync(verifiedAccount);

            // Act
            await studentAccountService.Create(data);

            // Assert
            userAccountServiceMock.Verify(e => e.SendEmailConfirmation(verifiedAccount), Times.Once);
        }
    }
}