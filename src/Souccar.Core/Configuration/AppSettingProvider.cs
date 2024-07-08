using System.Collections.Generic;
using System.Linq;
using Abp.Configuration;
using Microsoft.Extensions.Configuration;

namespace Souccar.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AppSettingProvider(IAppConfigurationAccessor configurationAccessor)
        {
            _appConfiguration = configurationAccessor.Configuration;
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return GetHcpcSettings().Union(GetSrssSettings()).Union(GetPesonnelSettings());
            
        }

        private IEnumerable<SettingDefinition> GetHcpcSettings()
        {
            return new[] {
                new SettingDefinition(AppSettingNames.Hcpc.ExpiryDurationNotify, GetFromSettings(AppSettingNames.Hcpc.ExpiryDurationNotify, "30"), isVisibleToClients: true)
            };
        }

        private IEnumerable<SettingDefinition> GetSrssSettings()
        {
            return new[] {
                new SettingDefinition(AppSettingNames.Srss.Url, GetFromSettings(AppSettingNames.Srss.Url, "http://localhost"), isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.Srss.Folder, GetFromSettings(AppSettingNames.Srss.Folder, "NewFolder"), isVisibleToClients: true)
            };
        }

        private IEnumerable<SettingDefinition> GetPesonnelSettings()
        {
            return new[] {
                new SettingDefinition(AppSettingNames.Personnel.Test, GetFromSettings(AppSettingNames.Personnel.Test, "testtest"), isVisibleToClients: true)
            };
        }

        private string GetFromSettings(string name, string defaultValue = null)
        {
            return _appConfiguration[name] ?? defaultValue;
        }

    }
}
