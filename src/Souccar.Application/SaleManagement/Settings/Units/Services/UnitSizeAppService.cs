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
    public class UnitSizeAppService : SouccarAppServiceBase, IUnitSizeAppService
    {
        private readonly IUnitSizeDomainService _unitSizeDomainService;
        public UnitSizeAppService(IUnitSizeDomainService unitSizeDomainService)
        {
            _unitSizeDomainService = unitSizeDomainService;
        }
        public PagedResultDto<UnitSizeDto> Read(PagedUnitSizeResultRequestDto input)
        {
            var query = _unitSizeDomainService.Filter(input.Keyword);
            var totalCount = query.Count();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var data = ObjectMapper.Map<List<UnitSizeDto>>(query);
            return new PagedResultDto<UnitSizeDto>(
                totalCount,
                 data
            );
        }
        public IList<UnitSizeDto> GetAll()
        {
            var list = _unitSizeDomainService.GetAll();
            return ObjectMapper.Map<IList<UnitSizeDto>>(list);
        }
        public async Task<UnitSizeDto> GetByIdAsync(int id)
        {
            var unitSize = await _unitSizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UnitSizeDto>(unitSize);
        }
        public async Task<UpdateUnitSizeDto> GetForEditAsync(int id)
        {
            var unitSize = await _unitSizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateUnitSizeDto>(unitSize);
        }
        public async Task<CreateUnitSizeDto> CreateAsync(CreateUnitSizeDto unitSizeDto)
        {
            var unitSize = ObjectMapper.Map<UnitSize>(unitSizeDto);
            var createdUnitSize = await _unitSizeDomainService.CreateAsync(unitSize);
            return ObjectMapper.Map<CreateUnitSizeDto>(createdUnitSize);
        }
        public async Task<UpdateUnitSizeDto> UpdateAsync(UpdateUnitSizeDto unitSizeDto)
        {
            var unitSize = ObjectMapper.Map<UnitSize>(unitSizeDto);
            var updatedUnitSize = await _unitSizeDomainService.UpdateAsync(unitSize);
            return ObjectMapper.Map<UpdateUnitSizeDto>(updatedUnitSize);
        }
        public async Task DeleteAsync(int id)
        {
            await _unitSizeDomainService.DeleteAsync(id);
        }
       protected virtual IQueryable<UnitSize> ApplyPaging(IQueryable<UnitSize> query, PagedUnitSizeResultRequestDto input)
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
       protected virtual IQueryable<UnitSize> ApplySorting(IQueryable<UnitSize> query, PagedUnitSizeResultRequestDto input)
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

