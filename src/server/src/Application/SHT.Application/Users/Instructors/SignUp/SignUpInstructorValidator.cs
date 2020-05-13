using FluentValidation;
using JetBrains.Annotations;
using SHT.Application.Users.Instructors.Contracts;

namespace SHT.Application.Users.Instructors.SignUp
{
    [UsedImplicitly]
    internal class SignUpInstructorValidator : AbstractValidator<SignUpInstructorRequest>
    {
        public SignUpInstructorValidator()
        {
            RuleFor(e => e.Data).NotNull().SetValidator(new DataValidator());
        }

        private class DataValidator : AbstractValidator<SignUpInstructorDataDto>
        {
            public DataValidator()
            {
                RuleFor(e => e.Email).NotEmpty().EmailAddress();
                RuleFor(e => e.Password).NotEmpty();
            }
        }
    }
}