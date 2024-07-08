using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.Sessions.Dto;

namespace Souccar.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
