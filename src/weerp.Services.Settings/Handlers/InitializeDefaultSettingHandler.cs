using System.Threading.Tasks;
using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using weerp.domain.Settings;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Messages.Commands;
using weerp.domain.Settings.Messages.Events;

namespace weerp.Services.Settings.Handlers
{
    public class InitializeDefaultSettingHandler : DomainCommandHandler<CreateDefaultsSettings, Setting>
    {
        public InitializeDefaultSettingHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Setting> repo) : base(busPublisher, mapper, repo)
        {
        }

        public override async Task HandleAsync(CreateDefaultsSettings command, ICorrelationContext context)
        {
           await base.HandleAsync(command, context);

            DefaultsSettings.Get.ForEach(async s =>
            {
                var setting = Mapper.Map<Setting>(s);
                await Repository.AddAsync(setting);

                CreateSetting cmd = Mapper.Map<CreateSetting>(setting);
                SettingCreated evt = Mapper.Map<SettingCreated>(cmd);
                await BusPublisher.PublishAsync(evt, context);
            });
           

        }
    }
}
