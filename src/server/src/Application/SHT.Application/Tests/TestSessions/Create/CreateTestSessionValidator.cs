using FluentValidation;
using JetBrains.Annotations;
using SHT.Application.Tests.TestSessions.Common;

namespace SHT.Application.Tests.TestSessions.Create
{
    [UsedImplicitly]
    internal class CreateTestSessionValidator : AbstractValidator<CreateTestSessionRequest>
    {
        public CreateTestSessionValidator()
        {
            RuleFor(e => e.Data).SetValidator(new TestSessionModificationDataDtoValidator());
        }
    }
}