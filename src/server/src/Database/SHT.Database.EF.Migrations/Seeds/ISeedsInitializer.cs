using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SHT.Database.EF.Migrations.Seeds
{
    public interface ISeedsInitializer
    {
        Task ApplyDevSeeds(DbContext context);
    }
}