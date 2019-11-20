using FluentValidation;
using JetBrains.Annotations;

namespace SHT.Application.Tests.TestSessions.Students.StateTransition
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