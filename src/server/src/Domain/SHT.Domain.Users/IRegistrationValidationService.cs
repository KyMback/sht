using System.Threading.Tasks;

namespace SHT.Domain.Users
{
    public interface IRegistrationValidationService
    {
        Task TrowsIfEmailIsNotUniq(string email);
    }
}