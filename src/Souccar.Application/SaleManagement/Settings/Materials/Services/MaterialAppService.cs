using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.SaleManagement.Settings.Materials.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public class MaterialAppService : SouccarAppServiceBase, IMaterialAppService
    {
        private readonly IMaterialDomainService _materialDomainService;
        public MaterialAppService(IMaterialDomainService materialDomainService)
        {
            _materialDomainService = materialDomainService;
        }
        public PagedResultDto<MaterialDto> Read(PagedMaterialResultRequestDto input)
        {
            var query = _materialDomainService.Filter(input.Keyword);
            var totalCount = query.Count();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var data = ObjectMapper.Map<List<MaterialDto>>(query);
            return new PagedResultDto<MaterialDto>(
                totalCount,
                 data
            );
        }
        public IList<MaterialDto> GetAll()
        {
            var list = _materialDomainService.GetAll();
            return ObjectMapper.Map<IList<MaterialDto>>(list);
        }
        public async Task<MaterialDto> GetByIdAsync(int id)
        {
            var material = await _materialDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialDto>(material);
        }
        public async Task<UpdateMaterialDto> GetForEditAsync(int id)
        {
            var material = await _materialDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateMaterialDto>(material);
        }
        public async Task<CreateMaterialDto> CreateAsync(CreateMaterialDto materialDto)
        {
            var material = ObjectMapper.Map<Material>(materialDto);
            var createdMaterial = await _materialDomainService.CreateAsync(material);
            return ObjectMapper.Map<CreateMaterialDto>(createdMaterial);
        }
        public async Task<UpdateMaterialDto> UpdateAsync(UpdateMaterialDto materialDto)
        {
            var material = ObjectMapper.Map<Material>(materialDto);
            var updatedMaterial = await _materialDomainService.UpdateAsync(material);
            return ObjectMapper.Map<UpdateMaterialDto>(updatedMaterial);
        }
        public async Task DeleteAsync(int id)
        {
            await _materialDomainService.DeleteAsync(id);
        }
       protected virtual IQueryable<Material> ApplyPaging(IQueryable<Material> query, PagedMaterialResultRequestDto input)
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
       protected virtual IQueryable<Material> ApplySorting(IQueryable<Material> query, PagedMaterialResultRequestDto input)
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

