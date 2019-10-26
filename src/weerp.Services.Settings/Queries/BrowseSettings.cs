using MicroS_Common.Types;
using weerp.domain.Settings.Dto;

namespace weerp.Services.Settings.Queries
{
    public class BrowseSettings : PagedQueryBase, IQuery<PagedResult<SettingDto>>
    {
        public string Type { get; set; }
    }
}
