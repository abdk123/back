using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Linq;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Souccar.Core.Services.Interfaces;
using System.Linq.Dynamic.Core;

namespace Souccar.Core.Services
{
    public abstract class AsyncSouccarAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
       : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>,
        IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        protected AsyncSouccarAppService(ISouccarDomainService<TEntity, TPrimaryKey> domainService)
            : base(domainService)
        {

        }

        public virtual async Task<TEntityDto> GetAsync(EntityDto<TPrimaryKey> input)
        {
            CheckGetPermission();

            var entity = await GetEntityByIdAsync(input.Id);
            return MapToEntityDto(entity);
        }

        public virtual async Task<TUpdateInput> GetForEditAsync(EntityDto<TPrimaryKey> input)
        {
            var data = await _domainService.GetAgreggateAsync(input.Id);
            return ObjectMapper.Map<TUpdateInput>(data);
        }

        public virtual async Task<PagedResultDto<TEntityDto>> GetAllAsync(TGetAllInput input)
        {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        public virtual async Task<PagedResultDto<TEntityDto>> ReadAsync(TGetAllInput input)
        {
          CheckGetAllPermission();

            var query = CreateFilteredQuery(input);

            query = ApplySearching(query, typeof(TEntityDto), input);
            query = ApplyFiltering(query, input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        public virtual async Task<TEntityDto> CreateAsync(TCreateInput input)
        {
            CheckCreatePermission();

            var entity = MapToEntity(input);

            await _domainService.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public virtual async Task<TEntityDto> UpdateAsync(TUpdateInput input)
        {
            CheckUpdatePermission();

            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public virtual Task DeleteAsync(EntityDto<TPrimaryKey> input)
        {
            CheckDeletePermission();

            return _domainService.DeleteAsync(input.Id);
        }

        protected virtual Task<TEntity> GetEntityByIdAsync(TPrimaryKey id)
        {
            if (typeof(TEntity).IsSubclassOf(typeof(FullAuditedAggregateRoot)))
            {
                return _domainService.GetAgreggateAsync(id);
            }
            return _domainService.GetAsync(id);
        }
    }
}