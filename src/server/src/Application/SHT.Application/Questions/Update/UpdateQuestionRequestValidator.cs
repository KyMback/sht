using FluentValidation;
using JetBrains.Annotations;
using SHT.Application.Questions.Validators;

namespace SHT.Application.Questions.Update
{
    [UsedImplicitly]
    internal class UpdateQuestionRequestValidator : AbstractValidator<UpdateQuestionRequest>
    {
        public UpdateQuestionRequestValidator()
        {
            RuleFor(e => e.Data).NotNull().SetValidator(new QuestionEditDetailsDtoValidator());
        }
    }
}