using Microsoft.Extensions.Configuration;

namespace Souccar.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
