using AutoMapper;
using MicroS_Common.Handlers;
using weerp.domain.Settings.Dto;
using weerp.Services.Settings.Domain;
using weerp.Services.Settings.Queries;
using weerp.Services.Settings.Repositories;

namespace weerp.Services.Settings.Handlers
{
    

    public sealed class BrowseSettingsHandler : BaseBrowseHandler<Setting, BrowseSettings, SettingDto, ISettingsRepository>
    {
        public BrowseSettingsHandler(ISettingsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

    }
}
