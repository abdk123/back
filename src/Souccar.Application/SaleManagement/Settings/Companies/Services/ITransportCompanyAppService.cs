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
    public interface ITransportCompanyAppService : IApplicationService
    {
        PagedResultDto<TransportCompanyDto> Read(PagedTransportCompanyResultRequestDto input);
        public IList<TransportCompanyDto> GetAll();
        Task<TransportCompanyDto> GetByIdAsync(int id);
        Task<UpdateTransportCompanyDto> GetForEditAsync(int id);
        Task<CreateTransportCompanyDto> CreateAsync(CreateTransportCompanyDto transportCompany);
        Task<UpdateTransportCompanyDto> UpdateAsync(UpdateTransportCompanyDto transportCompany);
        Task DeleteAsync(int id);
    }
}

