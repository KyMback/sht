using FluentValidation;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Models;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Questions.Validators
{
    internal class QuestionEditDetailsDtoValidator : AbstractValidator<QuestionEditDetailsDto>
    {
        public QuestionEditDetailsDtoValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(LengthConstants.Medium);
            When(e => e.Type == QuestionType.FreeText, () =>
            {
                RuleFor(e => e.FreeTextQuestionData).NotNull().SetValidator(new FreeTextQuestionDtoValidator());
            });
            When(e => e.Type == QuestionType.QuestionWithChoice, () =>
            {
                RuleFor(e => e.ChoiceQuestionData).NotNull().SetValidator(new ChoiceQuestionDtoValidator());
            });
        }
    }
}