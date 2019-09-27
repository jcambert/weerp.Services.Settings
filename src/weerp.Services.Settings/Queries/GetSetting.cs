using MicroS_Common.Types;
using System;
using weerp.Services.Settings.Dto;

namespace weerp.Services.Settings.Queries
{
    public class GetSetting : IQuery<SettingDto>
    {
        public Guid Id { get; set; }
    }
}
