namespace SHT.Domain.Models.Users
{
    public class Instructor : BaseEntity
    {
        public virtual Account Account { get; set; }
    }
}