using System.Threading.Tasks;

namespace SHT.Domain.Services.Users
{
    public interface IRegistrationValidationService
    {
        Task TrowsIfEmailIsNotUniq(string email);
    }
}