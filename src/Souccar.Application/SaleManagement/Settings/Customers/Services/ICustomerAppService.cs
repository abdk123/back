using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Settings.Customers.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public interface ICustomerAppService : IApplicationService
    {
        PagedResultDto<CustomerDto> Read(PagedCustomerResultRequestDto input);
        public IList<CustomerDto> GetAll();
        Task<CustomerDto> GetByIdAsync(int id);
        Task<UpdateCustomerDto> GetForEditAsync(int id);
        Task<CreateCustomerDto> CreateAsync(CreateCustomerDto customer);
        Task<UpdateCustomerDto> UpdateAsync(UpdateCustomerDto customer);
        Task DeleteAsync(int id);
    }
}

