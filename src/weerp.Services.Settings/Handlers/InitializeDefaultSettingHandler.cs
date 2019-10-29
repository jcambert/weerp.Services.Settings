using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using System.Threading.Tasks;
using weerp.domain.Settings;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Messages.Commands;

namespace weerp.Services.Settings.Handlers
{
    public class InitializeDefaultSettingHandler : DomainCommandHandler<CreateDefaultsSettings, Setting>
    {


        public InitializeDefaultSettingHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Setting> repo, IDomainValidation<Setting> validator=null) : base(busPublisher, mapper, repo,validator)
        {
          
        }


        public override async Task HandleAsync(CreateDefaultsSettings command, ICorrelationContext context)
        {
          
            DefaultsSettings.Get.ForEach(async s =>
            {
                Setting setting = Mapper.Map<Setting>(s);

                CreateSetting cmd = Mapper.Map<CreateSetting>(setting);
                
                await BusPublisher.SendAsync(cmd,context);
            });
           

        }
    }
}
