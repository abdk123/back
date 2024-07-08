using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.Authorization.Accounts.Dto;

namespace Souccar.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
