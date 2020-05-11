using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Domain.Models;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionVariantChoiceQuestionModificationDataValidator :
        AbstractValidator<TestSessionVariantChoiceQuestionModificationData>
    {
        public TestSessionVariantChoiceQuestionModificationDataValidator()
        {
            RuleFor(e => e.QuestionText).NotEmpty().MaximumLength(LengthConstants.Large);
            RuleFor(e => e.Options).NotEmpty();
            RuleForEach(e => e.Options).NotNull()
                .SetValidator(new TestSessionVariantChoiceQuestionOptionModificationDataValidator());
        }
    }
}