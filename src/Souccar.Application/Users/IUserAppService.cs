using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Roles.Dto;
using Souccar.Users.Dto;

namespace Souccar.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);

        Task<PagedResultDto<UserDto>> ReadAsync(FullPagedRequestDto input);

        Task<List<UserForDropdownDto>> GetForDropdown();

        Task<bool> ResetCurrentUserPesswordToDefault();
    }
}
