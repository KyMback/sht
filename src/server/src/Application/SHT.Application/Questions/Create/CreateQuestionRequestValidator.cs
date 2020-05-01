using FluentValidation;
using JetBrains.Annotations;
using SHT.Application.Questions.Validators;

namespace SHT.Application.Questions.Create
{
    [UsedImplicitly]
    internal class CreateQuestionRequestValidator : AbstractValidator<CreateQuestionRequest>
    {
        public CreateQuestionRequestValidator()
        {
            RuleFor(e => e.Data).NotNull().SetValidator(new QuestionEditDetailsDtoValidator());
        }
    }
}