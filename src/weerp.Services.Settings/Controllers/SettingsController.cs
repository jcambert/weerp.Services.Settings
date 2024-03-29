﻿using MicroS_Common.Controllers;
using MicroS_Common.Dispatchers;
using MicroS_Common.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using weerp.domain.Settings.Dto;
using weerp.domain.Settings.Queries;

namespace weerp.Services.Settings.Controllers
{
    [Route("[controller]")]
    public class SettingsController : BaseController
    {
        public SettingsController(IDispatcher dispatcher) : base(dispatcher)
        {
        }
        [HttpGet]
        public async Task<ActionResult<PagedResult<SettingDto>>> Get([FromQuery] BrowseSettings query)
           => Collection(await QueryAsync(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<SettingDto>> GetAsync([FromRoute] GetSetting query)
            => Single(await QueryAsync(query));

    }
}