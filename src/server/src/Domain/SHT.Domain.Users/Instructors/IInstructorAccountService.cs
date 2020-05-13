using System.Threading.Tasks;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Users.Instructors
{
    public interface IInstructorAccountService
    {
        Task<Instructor> Create(InstructorCreationData data);
    }
}