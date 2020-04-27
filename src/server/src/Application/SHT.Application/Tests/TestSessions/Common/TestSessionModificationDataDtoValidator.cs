using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionModificationDataDtoValidator : AbstractValidator<TestSessionModificationDataDto>
    {
        public TestSessionModificationDataDtoValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.StudentsIds).NotNull();
            RuleFor(e => e.TestVariants).NotNull();
            RuleForEach(e => e.TestVariants).SetValidator(new TestSessionVariantDataDtoValidator());
        }
    }
}