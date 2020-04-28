using MediatR;

namespace SHT.Application.Users.Accounts.ResendEmailConfirmation
{
    public class ResendEmailConfirmationRequest : IRequest
    {
        public ResendEmailConfirmationRequest(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}