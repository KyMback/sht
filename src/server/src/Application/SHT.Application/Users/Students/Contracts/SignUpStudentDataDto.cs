using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.Users.Students.Contracts
{
    [ApiDataContract]
    public class SignUpStudentDataDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Group { get; set; }
    }
}