using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Domain.Models;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionVariantFreeTextQuestionModificationDataValidator :
        AbstractValidator<TestSessionVariantFreeTextQuestionModificationData>
    {
        public TestSessionVariantFreeTextQuestionModificationDataValidator()
        {
            RuleFor(e => e.QuestionText).NotEmpty().MaximumLength(LengthConstants.Large);
        }
    }
}