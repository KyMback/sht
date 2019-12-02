namespace SHT.Domain.Models.Users
{
    public class Student : BaseEntity
    {
        public virtual Account Account { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }
    }
}