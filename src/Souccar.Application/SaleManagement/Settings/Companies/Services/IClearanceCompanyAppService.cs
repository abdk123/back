using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Settings.Companies.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface IClearanceCompanyAppService : IApplicationService
    {
        PagedResultDto<ClearanceCompanyDto> Read(PagedClearanceCompanyResultRequestDto input);
        public IList<ClearanceCompanyDto> GetAll();
        Task<ClearanceCompanyDto> GetByIdAsync(int id);
        Task<UpdateClearanceCompanyDto> GetForEditAsync(int id);
        Task<CreateClearanceCompanyDto> CreateAsync(CreateClearanceCompanyDto clearanceCompany);
        Task<UpdateClearanceCompanyDto> UpdateAsync(UpdateClearanceCompanyDto clearanceCompany);
        Task DeleteAsync(int id);
    }
}

