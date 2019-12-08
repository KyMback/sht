using FluentValidation;
using JetBrains.Annotations;
using SHT.Application.Tests.TestSessions.Common;

namespace SHT.Application.Tests.TestSessions.Update
{
    [UsedImplicitly]
    internal class UpdateTestSessionValidator : AbstractValidator<UpdateTestSessionRequest>
    {
        public UpdateTestSessionValidator()
        {
            RuleFor(e => e.Data).SetValidator(new TestSessionDetailsDtoValidator());
        }
    }
}