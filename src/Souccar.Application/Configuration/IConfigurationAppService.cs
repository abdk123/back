using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Souccar.Configuration.Dto;

namespace Souccar.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeSettings(IList<SettingInput> settings);
    }
}
