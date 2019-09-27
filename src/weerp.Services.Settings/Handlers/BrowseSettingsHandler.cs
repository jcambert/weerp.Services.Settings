using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weerp.Services.Settings.Domain;
using weerp.Services.Settings.Dto;
using weerp.Services.Settings.Queries;
using weerp.Services.Settings.Repositories;

namespace weerp.Services.Settings.Handlers
{
    /*public class BrowseSettingsHandler : IQueryHandler<BrowseSettings, PagedResult<SettingDto>>
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMapper _mapper;

        public BrowseSettingsHandler(ISettingsRepository productsRepository, IMapper mapper)
        {
            _settingsRepository = productsRepository;
            _mapper = mapper;
        }


        public async Task<PagedResult<SettingDto>> HandleAsync(BrowseSettings query)
        {
            var pagedResult = await _settingsRepository.BrowseAsync(query);
            var products = pagedResult.Items.Select(p =>_mapper.Map<Setting,SettingDto>(p) ).ToList();

            return PagedResult<SettingDto>.From(pagedResult, products);
        }
    }*/

    public class BrowseSettingsHandler : BaseBrowseHandler<Setting, BrowseSettings, SettingDto, SettingsRepository>
    {
        public BrowseSettingsHandler(IRepository<Setting> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        protected override Task<PagedResult<Setting>> BrowseAsync(BrowseSettings query) => Repository.BrowseAsync(query);
    }
}
