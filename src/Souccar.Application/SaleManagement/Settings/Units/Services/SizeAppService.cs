using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.SaleManagement.Settings.Units.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public class SizeAppService : SouccarAppServiceBase, ISizeAppService
    {
        private readonly ISizeDomainService _sizeDomainService;
        public SizeAppService(ISizeDomainService sizeDomainService)
        {
            _sizeDomainService = sizeDomainService;
        }
        public PagedResultDto<SizeDto> Read(PagedSizeResultRequestDto input)
        {
            var query = _sizeDomainService.Filter(input.Keyword);
            var totalCount = query.Count();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var data = ObjectMapper.Map<List<SizeDto>>(query);
            return new PagedResultDto<SizeDto>(
                totalCount,
                 data
            );
        }
        public IList<SizeDto> GetAll()
        {
            var list = _sizeDomainService.GetAll();
            return ObjectMapper.Map<IList<SizeDto>>(list);
        }
        public async Task<SizeDto> GetByIdAsync(int id)
        {
            var size = await _sizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<SizeDto>(size);
        }
        public async Task<UpdateSizeDto> GetForEditAsync(int id)
        {
            var size = await _sizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateSizeDto>(size);
        }
        public async Task<CreateSizeDto> CreateAsync(CreateSizeDto sizeDto)
        {
            var size = ObjectMapper.Map<Size>(sizeDto);
            var createdSize = await _sizeDomainService.CreateAsync(size);
            return ObjectMapper.Map<CreateSizeDto>(createdSize);
        }
        public async Task<UpdateSizeDto> UpdateAsync(UpdateSizeDto sizeDto)
        {
            var size = ObjectMapper.Map<Size>(sizeDto);
            var updatedSize = await _sizeDomainService.UpdateAsync(size);
            return ObjectMapper.Map<UpdateSizeDto>(updatedSize);
        }
        public async Task DeleteAsync(int id)
        {
            await _sizeDomainService.DeleteAsync(id);
        }
       protected virtual IQueryable<Size> ApplyPaging(IQueryable<Size> query, PagedSizeResultRequestDto input)
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
       protected virtual IQueryable<Size> ApplySorting(IQueryable<Size> query, PagedSizeResultRequestDto input)
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

