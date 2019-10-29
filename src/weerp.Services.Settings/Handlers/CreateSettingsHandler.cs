using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.domain.Settings;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Messages.Commands;
using weerp.domain.Settings.Messages.Events;
using weerp.Services.Settings.Repositories;

namespace weerp.Services.Settings.Handlers
{
    public sealed class CreateSettingsHandler : DomainCommandHandler<CreateSetting, Setting>
    {
        public CreateSettingsHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Setting> repo, IDomainValidation<Setting> validator = null) : base(busPublisher, mapper, repo,validator)
        {
        }

        protected override async Task CheckExist(Setting entity)
        {
            if (await(Repository as ISettingsRepository).ExistsAsync( entity.Numero))
            {
                throw new MicroSException(SettingErrorMessage.SETTING_ALREADY_EXIST.Code,string.Format(SettingErrorMessage.SETTING_ALREADY_EXIST.Message,entity.Numero));
            }
        }

        public override async Task HandleAsync(CreateSetting command, ICorrelationContext context)
        {
            await base.HandleAsync(command, context);

            var product = GetDomainObject(command);

            await Repository.AddAsync(product);

            await BusPublisher.PublishAsync(CreateEvent<SettingCreated>(command), context);
        }
    }
}
