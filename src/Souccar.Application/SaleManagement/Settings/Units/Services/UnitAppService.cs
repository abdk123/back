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
    public class UnitAppService : SouccarAppServiceBase, IUnitAppService
    {
        private readonly IUnitDomainService _unitDomainService;
        public UnitAppService(IUnitDomainService unitDomainService)
        {
            _unitDomainService = unitDomainService;
        }
        public PagedResultDto<UnitDto> Read(PagedUnitResultRequestDto input)
        {
            var query = _unitDomainService.Filter(input.Keyword);
            var totalCount = query.Count();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var data = ObjectMapper.Map<List<UnitDto>>(query);
            return new PagedResultDto<UnitDto>(
                totalCount,
                 data
            );
        }
        public IList<UnitDto> GetAll()
        {
            var list = _unitDomainService.GetAll();
            return ObjectMapper.Map<IList<UnitDto>>(list);
        }
        public async Task<UnitDto> GetByIdAsync(int id)
        {
            var unit = await _unitDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UnitDto>(unit);
        }
        public async Task<UpdateUnitDto> GetForEditAsync(int id)
        {
            var unit = await _unitDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateUnitDto>(unit);
        }
        public async Task<CreateUnitDto> CreateAsync(CreateUnitDto unitDto)
        {
            var unit = ObjectMapper.Map<Unit>(unitDto);
            var createdUnit = await _unitDomainService.CreateAsync(unit);
            return ObjectMapper.Map<CreateUnitDto>(createdUnit);
        }
        public async Task<UpdateUnitDto> UpdateAsync(UpdateUnitDto unitDto)
        {
            var unit = ObjectMapper.Map<Unit>(unitDto);
            var updatedUnit = await _unitDomainService.UpdateAsync(unit);
            return ObjectMapper.Map<UpdateUnitDto>(updatedUnit);
        }
        public async Task DeleteAsync(int id)
        {
            await _unitDomainService.DeleteAsync(id);
        }
       protected virtual IQueryable<Unit> ApplyPaging(IQueryable<Unit> query, PagedUnitResultRequestDto input)
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
       protected virtual IQueryable<Unit> ApplySorting(IQueryable<Unit> query, PagedUnitResultRequestDto input)
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

