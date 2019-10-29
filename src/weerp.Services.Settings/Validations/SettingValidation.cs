using MicroS_Common.Handlers;
using System.Threading.Tasks;
using weerp.domain.Settings;
using weerp.domain.Settings.Domain;
using weerp.Services.Settings.Repositories;

namespace weerp.Services.Settings.Validation
{
    public class SettingValidation : IDomainValidation<Setting>
    {
        public SettingValidation()
        {
            this.ErrorMessages = new SettingErrorMessage();
        }

        public SettingErrorMessage ErrorMessages { get; }

        public void Validate(Setting setting)
        {

            ErrorMessages.AddIf(() => setting.Numero <= 0, SettingErrorMessage.SETTING_NUMBER_POSITIVE);
            ErrorMessages.AddIf(() => setting.Categorie.Length == 0, SettingErrorMessage.SETTING_CATEGORY_NEEDED, setting.Numero.ToString());
            ErrorMessages.AddIf(() => setting.Description.Length == 0, SettingErrorMessage.SETTING_DESCRIPTION_NEEDED, setting.Numero.ToString());
            ErrorMessages.AddIf(() => setting.Type.Length == 0, SettingErrorMessage.SETTING_TYPE_NEEDED, setting.Numero.ToString());

            ErrorMessages.Throw();
        }
    }
}
