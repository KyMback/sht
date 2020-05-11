using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Domain.Models;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionVariantChoiceQuestionOptionModificationDataValidator :
        AbstractValidator<TestSessionVariantChoiceQuestionOptionModificationData>
    {
        public TestSessionVariantChoiceQuestionOptionModificationDataValidator()
        {
            RuleFor(e => e.Text).NotEmpty().MaximumLength(LengthConstants.Large);
        }
    }
}