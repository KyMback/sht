using FluentValidation;
using JetBrains.Annotations;

namespace SHT.Application.Users.Accounts.ConfirmEmail
{
    [UsedImplicitly]
    internal class ConfirmEmailValidator : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailValidator()
        {
            RuleFor(e => e.Data).SetValidator(new DataValidator());
        }

        private class DataValidator : AbstractValidator<ConfirmEmailDataDto>
        {
            public DataValidator()
            {
                RuleFor(e => e.Email).NotEmpty().EmailAddress();
                RuleFor(e => e.Token).NotEmpty();
            }
        }
    }
}