using System.Threading.Tasks;
using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using weerp.Services.Settings.Domain;
using weerp.Services.Settings.Messages.Commands;
using weerp.Services.Settings.Messages.Events;
using weerp.Services.Settings.Repositories;

namespace weerp.Services.Settings.Handlers
{
    public sealed class CreateSettingsHandler : DomainCommandHandler<CreateSetting, Setting>
    {
        public CreateSettingsHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Setting> repo) : base(busPublisher, mapper, repo)
        {
        }

        protected override async Task CheckExist(CreateSetting command)
        {
            if (await(Repository as ISettingsRepository).ExistsAsync( command.Numero))
            {
                throw new MicroSException("setting_already_exists",$"Setting: '{command.Numero}' already exists.");
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
