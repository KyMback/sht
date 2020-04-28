namespace SHT.Domain.Models.Users
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        /// <remarks>
        /// Represents current version of user credentials
        /// </remarks>
        public string SecurityStamp { get; set; }

        public UserType UserType { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}