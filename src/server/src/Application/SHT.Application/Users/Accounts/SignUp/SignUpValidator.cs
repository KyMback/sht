using FluentValidation;
using JetBrains.Annotations;

namespace SHT.Application.Users.Accounts.SignUp
{
    [UsedImplicitly]
    internal class SignUpValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpValidator()
        {
            RuleFor(e => e.Data).NotNull().SetValidator(new DataValidator());
        }

        private class DataValidator : AbstractValidator<SignUpDataDto>
        {
            public DataValidator()
            {
                RuleFor(e => e.Login).NotEmpty();
                RuleFor(e => e.Password).NotEmpty();
            }
        }
    }
}