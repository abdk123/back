using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Roles.Dto;

namespace Souccar.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);

        IList<RoleNameDto> GetAllRolesNames();

        Task<PagedResultDto<RoleDto>> ReadAsync(FullPagedRequestDto input);
    }
}
