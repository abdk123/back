using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Linq.Extensions;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Souccar.Core.Services.Interfaces;
using Souccar.Core.Includes;
using Souccar.Core.ResultRequests;
using System.Linq.Expressions;

namespace Souccar.Core.Services
{
    public abstract class CoreAppServiceBase<TEntity, TEntityDto, TGetAllInput, TCreateInput, TUpdateInput> : ApplicationService
        where TEntity : class, IEntity<int>
        where TEntityDto : IEntityDto<int>
        where TUpdateInput : IEntityDto<int>
    {
        protected readonly ICoreDomainService<TEntity> _coreDomainService;

        protected virtual string GetPermissionName { get; set; }

        protected virtual string GetAllPermissionName { get; set; }

        protected virtual string CreatePermissionName { get; set; }

        protected virtual string UpdatePermissionName { get; set; }

        protected virtual string DeletePermissionName { get; set; }

        protected CoreAppServiceBase(ICoreDomainService<TEntity> coreDomainService)
        {
            _coreDomainService = coreDomainService;
        }

        /// <summary>
        /// Should apply sorting if needed.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, TGetAllInput input)
        {
            //Try to sort query if available
            var sortInput = input as ISortedResultRequest;
            if (sortInput != null)
            {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    return query.OrderBy(sortInput.Sorting);
                }
            }

            //IQueryable.Task requires sorting, so we should sort if Take will be used.
            if (input is ILimitedResultRequest)
            {
                return query.OrderByDescending(e => e.Id);
            }

            //No sorting
            return query;
        }

        protected virtual string[] ApplyIncludes(string input)
        {
            if (input.Contains(','))
            {
                return input.Split(',');
            }
            return new string[1]{ input };
        }

        /// <summary>
        /// Should apply paging if needed.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, TGetAllInput input)
        {
            //Try to use paging if available
            var pagedInput = input as IPagedResultRequest;
            if (pagedInput != null)
            {
                return query.PageBy(pagedInput);
            }

            //Try to limit query result if available
            var limitedInput = input as ILimitedResultRequest;
            if (limitedInput != null)
            {
                return query.Take(limitedInput.MaxResultCount);
            }

            //No paging
            return query;
        }

        /// <summary>
        /// This method should create <see cref="IQueryable{TEntity}"/> based on given input.
        /// It should filter query if needed, but should not do sorting or paging.
        /// Sorting should be done in <see cref="ApplySorting"/> and paging should be done in <see cref="ApplyPaging"/>
        /// methods.
        /// </summary>
        /// <param name="input">The input.</param>
        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression(TGetAllInput input)
        {
            return null;
        }

        /// <summary>
        /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TEntityDto"/>.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual TEntityDto MapToEntityDto(TEntity entity)
        {
            return ObjectMapper.Map<TEntityDto>(entity);
        }

        /// <summary>
        /// Maps <typeparamref name="TEntityDto"/> to <typeparamref name="TEntity"/> to create a new entity.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual TEntity MapToEntity(TCreateInput createInput)
        {
            return ObjectMapper.Map<TEntity>(createInput);
        }

        /// <summary>
        /// Maps <typeparamref name="TUpdateInput"/> to <typeparamref name="TEntity"/> to update the entity.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual void MapToEntity(TUpdateInput updateInput, TEntity entity)
        {
            ObjectMapper.Map(updateInput, entity);
        }

        protected virtual void CheckPermission(string permissionName)
        {
            if (!string.IsNullOrEmpty(permissionName))
            {
                PermissionChecker.Authorize(permissionName);
            }
        }

        protected virtual void CheckGetPermission()
        {
            CheckPermission(GetPermissionName);
        }

        protected virtual void CheckGetAllPermission()
        {
            CheckPermission(GetAllPermissionName);
        }

        protected virtual void CheckCreatePermission()
        {
            CheckPermission(CreatePermissionName);
        }

        protected virtual void CheckUpdatePermission()
        {
            CheckPermission(UpdatePermissionName);
        }

        protected virtual void CheckDeletePermission()
        {
            CheckPermission(DeletePermissionName);
        }
    }
}
