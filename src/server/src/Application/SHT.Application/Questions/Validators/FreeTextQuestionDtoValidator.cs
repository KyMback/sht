using FluentValidation;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Models;

namespace SHT.Application.Questions.Validators
{
    internal class FreeTextQuestionDtoValidator : AbstractValidator<FreeTextQuestionDto>
    {
        public FreeTextQuestionDtoValidator()
        {
            RuleFor(e => e.Question).NotEmpty().MaximumLength(LengthConstants.Large);
        }
    }
}