using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Linq;
using System.Linq;
using System.Threading.Tasks;
using Souccar.Core.Services.Interfaces;
using Souccar.Core.ResultRequests;

namespace Souccar.Core.Services
{
    public abstract class CoreAppService<TEntity, TEntityDto, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
       : CoreAppServiceBase<TEntity, TEntityDto, TGetAllInput, TCreateInput, TUpdateInput>,
        ICoreAppService<TEntityDto, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
           where TEntity : class, IEntity<int>
           where TEntityDto : IEntityDto<int>
           where TUpdateInput : IEntityDto<int>
           where TGetInput : IEntityDto<int>
           where TDeleteInput : IEntityDto<int>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        protected CoreAppService(ICoreDomainService<TEntity> domainService)
            : base(domainService)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        public virtual async Task<TEntityDto> GetByIdAsync(TGetInput input, string including)
        {
            CheckGetPermission();
            var includes = ApplyIncludes(including);
            var entity = await GetEntityByIdAsync(input.Id, includes);
            return MapToEntityDto(entity);
        }

        public virtual PagedResultDto<TEntityDto> GetAll(TGetAllInput input)
        {
            CheckGetAllPermission();
            var pagedRequest = input as CorePagedRequestDto;
            var includes = ApplyIncludes(pagedRequest.Including);
            var expression = CreateFilterExpression(input);

            var pagedResult = _coreDomainService.GetPage(
                expression: expression,
                skip: pagedRequest.SkipCount,
                take: pagedRequest.MaxResultCount,
                includes: includes,
                sort: pagedRequest.Sorting);

            return new PagedResultDto<TEntityDto>(
                pagedResult.TotalCount,
                pagedResult.Items.Select(MapToEntityDto).ToList()
            );
        }

        
        public virtual async Task<TEntityDto> CreateAsync(TCreateInput input, string including)
        {
            CheckCreatePermission();

            var entity = MapToEntity(input);
            var includes = ApplyIncludes(including);
            await _coreDomainService.CreateAsync(entity, includes);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public virtual async Task<TEntityDto> UpdateAsync(TUpdateInput input, string including)
        {
            CheckUpdatePermission();
            var includes = ApplyIncludes(including);
            var entity = await GetEntityByIdAsync(input.Id, includes);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public virtual Task DeleteAsync(TDeleteInput input)
        {
            CheckDeletePermission();

            return _coreDomainService.DeleteAsync(input.Id);
        }

        protected virtual Task<TEntity> GetEntityByIdAsync(int id, string[] includes)
        {
            return _coreDomainService.GetByIdAsync(id,includes: includes);
        }

    }
}
