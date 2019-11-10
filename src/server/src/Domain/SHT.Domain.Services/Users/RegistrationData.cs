using SHT.Domain.Models.Users;

namespace SHT.Domain.Services.Users
{
    public class RegistrationData
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}