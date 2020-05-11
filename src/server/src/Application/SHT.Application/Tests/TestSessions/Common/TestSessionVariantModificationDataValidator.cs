using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Domain.Models;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionVariantModificationDataValidator : AbstractValidator<TestSessionVariantModificationData>
    {
        public TestSessionVariantModificationDataValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(LengthConstants.Medium);
            RuleFor(e => e.Questions).NotNull();
            RuleForEach(e => e.Questions).NotNull()
                .SetValidator(new TestSessionVariantQuestionModificationDataValidator());
        }
    }
}