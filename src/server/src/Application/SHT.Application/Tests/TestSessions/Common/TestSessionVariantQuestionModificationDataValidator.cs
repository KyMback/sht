using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Domain.Models;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionVariantQuestionModificationDataValidator :
        AbstractValidator<TestSessionVariantQuestionModificationData>
    {
        public TestSessionVariantQuestionModificationDataValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(LengthConstants.Medium);
            RuleFor(e => e.Order).GreaterThanOrEqualTo(1);
            When(e => e.Type == QuestionType.FreeText, () =>
            {
                RuleFor(e => e.FreeTextQuestion).NotNull()
                    .SetValidator(new TestSessionVariantFreeTextQuestionModificationDataValidator());
                RuleFor(e => e.ChoiceQuestion).Null();
            });
            When(e => e.Type == QuestionType.QuestionWithChoice, () =>
            {
                RuleFor(e => e.ChoiceQuestion).NotNull()
                    .SetValidator(new TestSessionVariantChoiceQuestionModificationDataValidator());
                RuleFor(e => e.FreeTextQuestion).Null();
            });
        }
    }
}