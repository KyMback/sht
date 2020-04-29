using System.Threading.Tasks;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Services.Users.Students
{
    public interface IStudentAccountService
    {
        Task<Student> Create(StudentCreationData data);
    }
}