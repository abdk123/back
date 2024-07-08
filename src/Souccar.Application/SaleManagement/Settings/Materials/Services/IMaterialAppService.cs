using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Settings.Materials.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public interface IMaterialAppService : IApplicationService
    {
        PagedResultDto<MaterialDto> Read(PagedMaterialResultRequestDto input);
        public IList<MaterialDto> GetAll();
        Task<MaterialDto> GetByIdAsync(int id);
        Task<UpdateMaterialDto> GetForEditAsync(int id);
        Task<CreateMaterialDto> CreateAsync(CreateMaterialDto material);
        Task<UpdateMaterialDto> UpdateAsync(UpdateMaterialDto material);
        Task DeleteAsync(int id);
    }
}

