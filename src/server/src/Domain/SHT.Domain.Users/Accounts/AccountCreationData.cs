using SHT.Domain.Models.Users;

namespace SHT.Domain.Services.Users.Accounts
{
    public class AccountCreationData
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}