using MicroS_Common.Mongo;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Queries;

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
