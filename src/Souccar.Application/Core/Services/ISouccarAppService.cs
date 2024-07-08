using Abp.Application.Services.Dto;
using Abp.Application.Services;

namespace Souccar.Core.Services
{
    public interface ISouccarAppService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput, in TGetInput, in TDeleteInput>
        : IApplicationService
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        TEntityDto Get(TGetInput input);

        PagedResultDto<TEntityDto> GetAll(TGetAllInput input);

        TEntityDto Create(TCreateInput input);

        TEntityDto Update(TUpdateInput input);

        void Delete(TDeleteInput input);
    }
}
