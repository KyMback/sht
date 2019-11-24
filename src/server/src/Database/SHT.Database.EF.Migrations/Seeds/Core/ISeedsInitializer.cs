using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SHT.Database.EF.Migrations.Seeds.Core
{
    public interface ISeedsInitializer
    {
        Task ApplySeeds(DbContext context);
    }
}