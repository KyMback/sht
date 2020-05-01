using FluentValidation;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Models;

namespace SHT.Application.Questions.Validators
{
    internal class ChoiceQuestionDtoValidator : AbstractValidator<ChoiceQuestionDto>
    {
        public ChoiceQuestionDtoValidator()
        {
            RuleFor(e => e.QuestionText).NotEmpty().MaximumLength(LengthConstants.Large);
            RuleFor(e => e.Options).NotEmpty()
                .ForEach(collection => collection.SetValidator(new ChoiceQuestionOptionDtoValidator()));
        }
    }
}