using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Authorization;
using Souccar.Configuration.Dto;


namespace Souccar.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SouccarAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeSettings(IList<SettingInput> settings)
        {
            foreach (var setting in settings)
            {
                await SettingManager.ChangeSettingForApplicationAsync(setting.Name, setting.Value);
            }
        }
    }
}
