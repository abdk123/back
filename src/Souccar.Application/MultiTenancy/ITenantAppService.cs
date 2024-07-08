using Abp.Application.Services;
using Souccar.MultiTenancy.Dto;

namespace Souccar.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

