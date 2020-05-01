using FluentValidation;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Models;

namespace SHT.Application.Questions.Validators
{
    internal class ChoiceQuestionOptionDtoValidator : AbstractValidator<ChoiceQuestionOptionDto>
    {
        public ChoiceQuestionOptionDtoValidator()
        {
            RuleFor(e => e.Text).NotEmpty().MaximumLength(LengthConstants.Large);
        }
    }
}