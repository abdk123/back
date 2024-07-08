using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Settings.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Categories.Services
{
    public interface ICategoryAppService : IApplicationService
    {
        PagedResultDto<CategoryDto> Read(PagedCategoryResultRequestDto input);
        public IList<CategoryDto> GetAll();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<UpdateCategoryDto> GetForEditAsync(int id);
        Task<CreateCategoryDto> CreateAsync(CreateCategoryDto category);
        Task<UpdateCategoryDto> UpdateAsync(UpdateCategoryDto category);
        Task DeleteAsync(int id);
    }
}

