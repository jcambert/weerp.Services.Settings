using System.Threading.Tasks;
using MicroS_Common.Mongo;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using weerp.Services.Settings.Domain;
using weerp.Services.Settings.Queries;

namespace weerp.Services.Settings.Repositories
{
    public class SettingsRepository : BaseRepository<Setting>, ISettingsRepository
    {
        public SettingsRepository(IMongoRepository<Setting> repository) : base(repository)
        {
        }

        public async Task<PagedResult<Setting>> BrowseAsync(BrowseSettings query) 
            => await Repository.BrowseAsync(e =>true, query);

        public async Task<bool> ExistsAsync(int numero) => await Repository.ExistsAsync(p => p.Numero == numero);
    }
}
