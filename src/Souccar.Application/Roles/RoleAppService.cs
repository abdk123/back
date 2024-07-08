using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Souccar.Authorization;
using Souccar.Authorization.Roles;
using Souccar.Authorization.Users;
using Souccar.Roles.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Dto.PagedRequests;
using System;
using Souccar.Core.Filter;
using Souccar.Core.Search;
using System.Linq.Dynamic.Core;

namespace Souccar.Roles
{
    [AbpAuthorize(PermissionNames.Security_Roles)]
    public class RoleAppService : AsyncCrudAppService<Role, RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>, IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        public IFilterBuilder<Role, int> FilterBuilder { get; set; }

        public RoleAppService(IRepository<Role> repository, RoleManager roleManager, UserManager userManager)
            : base(repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            FilterBuilder = NullFilterBuilder<Role, int>.Instance;
        }

        public override async Task<RoleDto> CreateAsync(CreateRoleDto input)
        {
            CheckCreatePermission();

            var role = ObjectMapper.Map<Role>(input);
            role.SetNormalizedName();

            CheckErrors(await _roleManager.CreateAsync(role));

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }

        public async Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input)
        {
            var roles = await _roleManager
                .Roles
                .WhereIf(
                    !input.Permission.IsNullOrWhiteSpace(),
                    r => r.Permissions.Any(rp => rp.Name == input.Permission && rp.IsGranted)
                )
                .ToListAsync();

            return new ListResultDto<RoleListDto>(ObjectMapper.Map<List<RoleListDto>>(roles));
        }

        public override async Task<RoleDto> UpdateAsync(RoleDto input)
        {
            CheckUpdatePermission();

            var role = await _roleManager.GetRoleByIdAsync(input.Id);

            ObjectMapper.Map(input, role);

            CheckErrors(await _roleManager.UpdateAsync(role));

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var role = await _roleManager.FindByIdAsync(input.Id.ToString());
            var users = await _userManager.GetUsersInRoleAsync(role.NormalizedName);

            foreach (var user in users)
            {
                CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.NormalizedName));
            }

            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(new ListResultDto<PermissionDto>(
                ObjectMapper.Map<List<PermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList()
            ));
        }

        //protected override IQueryable<Role> CreateFilteredQuery(PagedRoleResultRequestDto input)
        //{
        //    //return Repository.GetAllIncluding(x => x.Permissions)
        //    //    .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword)
        //    //    || x.DisplayName.Contains(input.Keyword)
        //    //    || x.Description.Contains(input.Keyword));

        //    return Repository.GetAllIncluding(x => x.Permissions);
        //}

        protected override async Task<Role> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAllIncluding(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == id);
        }

        //protected override IQueryable<Role> ApplySorting(IQueryable<Role> query, PagedRoleResultRequestDto input)
        //{
        //    return query.OrderBy(r => r.DisplayName);
        //}

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input)
        {
            var permissions = PermissionManager.GetAllPermissions();
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            var grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
            var roleEditDto = ObjectMapper.Map<RoleEditDto>(role);

            return new GetRoleForEditOutput
            {
                Role = roleEditDto,
                Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
            };
        }

        public IList<RoleNameDto> GetAllRolesNames()
        {
            var roles = _roleManager.GetAllRoles();
            return ObjectMapper.Map<IList<RoleNameDto>>(roles);
        }       

        public async Task<PagedResultDto<RoleDto>> ReadAsync(FullPagedRequestDto input)
        {
            var query = GetAllRoles();

            query = ApplySearching(query, typeof(RoleDto), input);
            query = ApplyFiltering(query, input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<RoleDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }


        #region Helper Methods
        private IQueryable<Role> ApplyFiltering(IQueryable<Role> query, FullPagedRequestDto input)
        {
            var filterInput = input as IFilterResultRequest;
            if (filterInput != null)
            {
                return FilterBuilder.Filter(query, filterInput.Filtering);
            }

            //No sorting
            return query;
        }

        private IQueryable<Role> ApplySearching(IQueryable<Role> query, Type typeDto, FullPagedRequestDto input)
        {
            var searchInput = input as ISearchResultRequest;
            if (searchInput != null)
            {
                return FilterBuilder.Search(query, typeDto, searchInput.Keyword);
            }

            //No sorting
            return query;
        }

        private IQueryable<Role> ApplySorting(IQueryable<Role> query, FullPagedRequestDto input)
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

        private IQueryable<Role> ApplyPaging(IQueryable<Role> query, FullPagedRequestDto input)
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

        private IQueryable<Role> GetAllRoles()
        {
            return Repository.GetAllIncluding(x => x.Permissions);
        }
        #endregion
    }
}

