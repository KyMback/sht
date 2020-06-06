using SHT.Application.Common;

namespace SHT.Application.Users.Students.Contracts
{
    [ApiDataContract]
    public class StudentProfileModificationDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }
    }
}