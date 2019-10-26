using MicroS_Common.Repository;
using System.Threading.Tasks;
using weerp.domain.Settings.Dto;
using weerp.Services.Settings.Domain;
using weerp.Services.Settings.Queries;

namespace weerp.Services.Settings.Repositories
{
    public interface ISettingsRepository : IBrowseRepository<Setting, BrowseSettings,SettingDto>
    {
        Task<bool> ExistsAsync(int numero);
    }
}
