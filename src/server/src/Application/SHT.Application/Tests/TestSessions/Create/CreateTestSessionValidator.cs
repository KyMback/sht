using FluentValidation;
using JetBrains.Annotations;

namespace SHT.Application.Tests.TestSessions.Create
{
    [UsedImplicitly]
    internal class CreateTestSessionValidator : AbstractValidator<CreateTestSessionRequest>
    {
        public CreateTestSessionValidator()
        {
            RuleFor(e => e.Data.Name).NotEmpty();
        }
    }
}