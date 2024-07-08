using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.SaleManagement.Settings.Stores.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Souccar.SaleManagement.Settings.Stores.Services
{
    public class StoreAppService : SouccarAppServiceBase, IStoreAppService
    {
        private readonly IStoreDomainService _storeDomainService;
        public StoreAppService(IStoreDomainService storeDomainService)
        {
            _storeDomainService = storeDomainService;
        }
        public PagedResultDto<StoreDto> Read(PagedStoreResultRequestDto input)
        {
            var query = _storeDomainService.Filter(input.Keyword);
            var totalCount = query.Count();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var data = ObjectMapper.Map<List<StoreDto>>(query);
            return new PagedResultDto<StoreDto>(
                totalCount,
                 data
            );
        }
        public IList<StoreDto> GetAll()
        {
            var list = _storeDomainService.GetAll();
            return ObjectMapper.Map<IList<StoreDto>>(list);
        }
        public async Task<StoreDto> GetByIdAsync(int id)
        {
            var store = await _storeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<StoreDto>(store);
        }
        public async Task<UpdateStoreDto> GetForEditAsync(int id)
        {
            var store = await _storeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateStoreDto>(store);
        }
        public async Task<CreateStoreDto> CreateAsync(CreateStoreDto storeDto)
        {
            var store = ObjectMapper.Map<Store>(storeDto);
            var createdStore = await _storeDomainService.CreateAsync(store);
            return ObjectMapper.Map<CreateStoreDto>(createdStore);
        }
        public async Task<UpdateStoreDto> UpdateAsync(UpdateStoreDto storeDto)
        {
            var store = ObjectMapper.Map<Store>(storeDto);
            var updatedStore = await _storeDomainService.UpdateAsync(store);
            return ObjectMapper.Map<UpdateStoreDto>(updatedStore);
        }
        public async Task DeleteAsync(int id)
        {
            await _storeDomainService.DeleteAsync(id);
        }
       protected virtual IQueryable<Store> ApplyPaging(IQueryable<Store> query, PagedStoreResultRequestDto input)
       {
            var pagedInput = input as IPagedResultRequest;
            if (pagedInput != null)
             {
                return query.PageBy(pagedInput);
             }

            var limitedInput = input as ILimitedResultRequest;
            if (limitedInput != null)
             {
                return query.Take(limitedInput.MaxResultCount);
             }
            return query;
       }
       protected virtual IQueryable<Store> ApplySorting(IQueryable<Store> query, PagedStoreResultRequestDto input)
       {
            var sortInput = input as ISortedResultRequest;
            if (sortInput != null)
             {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    return query.OrderBy(sortInput.Sorting);
                }
             }

            if (input is ILimitedResultRequest)
             {
                return query.OrderByDescending(e => e.Id);
             }
            return query;
       }
    }
}

