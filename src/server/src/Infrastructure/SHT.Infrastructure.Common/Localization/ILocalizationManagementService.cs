using System.Globalization;
using System.Threading.Tasks;

namespace SHT.Infrastructure.Common.Localization
{
    public interface ILocalizationManagementService
    {
        Task SetCulture(CultureInfo info);
    }
}