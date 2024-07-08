using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Linq;
using Souccar.Core.Services.Interfaces;

namespace Souccar.Core.Services
{
    public abstract class CrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
       : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>,
        ISouccarAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
           where TGetInput : IEntityDto<TPrimaryKey>
           where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        protected CrudAppService(ISouccarDomainService<TEntity, TPrimaryKey> domainService)
            : base(domainService)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        public virtual TEntityDto Get(TGetInput input)
        {
            CheckGetPermission();

            var entity = GetEntityById(input.Id);
            return MapToEntityDto(entity);
        }

        public virtual PagedResultDto<TEntityDto> GetAll(TGetAllInput input)
        {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = query.Count();

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = query.ToList();

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        public virtual TEntityDto Create(TCreateInput input)
        {
            CheckCreatePermission();

            var entity = MapToEntity(input);

            _domainService.Insert(entity);
            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(entity);
        }

        public virtual TEntityDto Update(TUpdateInput input)
        {
            CheckUpdatePermission();

            var entity = GetEntityById(input.Id);

            MapToEntity(input, entity);
            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(entity);
        }

        public virtual void Delete(TDeleteInput input)
        {
            CheckDeletePermission();

            _domainService.Delete(input.Id);
        }

        protected virtual TEntity GetEntityById(TPrimaryKey id)
        {
            return _domainService.Get(id);
        }
    }
}