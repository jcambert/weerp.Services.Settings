using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.Services.Settings.Domain;
using weerp.Services.Settings.Queries;

namespace weerp.Services.Settings.Repositories
{
    public interface ISettingsRepository : IRepository<Setting>
    {
        Task<bool> ExistsAsync(int numero);
        Task<PagedResult<Setting>> BrowseAsync(BrowseSettings query);
    }
}
