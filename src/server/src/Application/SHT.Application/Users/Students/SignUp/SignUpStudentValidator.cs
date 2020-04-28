using FluentValidation;
using JetBrains.Annotations;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Application.Users.Students.SignUp
{
    [UsedImplicitly]
    internal class SignUpStudentValidator : AbstractValidator<SignUpStudentRequest>
    {
        public SignUpStudentValidator()
        {
            RuleFor(e => e.Data).NotNull().SetValidator(new DataValidator());
        }

        private class DataValidator : AbstractValidator<SignUpStudentDataDto>
        {
            public DataValidator()
            {
                RuleFor(e => e.Email).NotEmpty().EmailAddress();
                RuleFor(e => e.Password).NotEmpty();
                RuleFor(e => e.FirstName).NotEmpty();
                RuleFor(e => e.LastName).NotEmpty();
            }
        }
    }
}