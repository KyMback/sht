using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.Users.Instructors.Contracts
{
    [ApiDataContract]
    public class SignUpInstructorDataDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}