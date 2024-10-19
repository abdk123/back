using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Threading.Tasks;

namespace Souccar.Core.Services
{
    public interface ICoreAppService<TEntityDto, in TGetAllInput, in TCreateInput, in TUpdateInput, in TGetInput, in TDeleteInput>
        : IApplicationService
        where TEntityDto : IEntityDto<int>
        where TUpdateInput : IEntityDto<int>
        where TGetInput : IEntityDto<int>
        where TDeleteInput : IEntityDto<int>
    {
        Task<TEntityDto> GetByIdAsync(TGetInput input, string including);

        PagedResultDto<TEntityDto> GetAll(TGetAllInput input);

        Task<TEntityDto> CreateAsync(TCreateInput input, string Including);

        Task<TEntityDto> UpdateAsync(TUpdateInput input, string Including);

        Task DeleteAsync(TDeleteInput input);
    }
}
