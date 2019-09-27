using System;
using MicroS_Common.Messages;

namespace weerp.Services.Settings.Messages.Events
{
    public class CreateSettingRejected : BaseRejectedEvent
    {
        public CreateSettingRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
