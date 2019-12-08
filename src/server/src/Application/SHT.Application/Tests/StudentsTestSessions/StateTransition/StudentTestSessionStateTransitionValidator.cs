using FluentValidation;
using JetBrains.Annotations;

namespace SHT.Application.Tests.StudentsTestSessions.StateTransition
{
    [UsedImplicitly]
    internal class StudentTestSessionStateTransitionValidator : AbstractValidator<StudentTestSessionStateTransitionRequest>
    {
        public StudentTestSessionStateTransitionValidator()
        {
            RuleFor(e => e.Trigger).NotEmpty();
        }
    }
}