using Souccar.SaleManagement.Settings.Customers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public interface ICustomerAppService : IAsyncSouccarAppService<CustomerDto, int, FullPagedRequestDto, CreateCustomerDto, UpdateCustomerDto>
    {
        IList<DropdownDto> GetForDropdownAsync();
    }
}

