using Souccar.SaleManagement.Settings.Customers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public interface ICustomerVoucherAppService : IAsyncSouccarAppService<CustomerVoucherDto, int, FullPagedRequestDto, CreateCustomerVoucherDto, UpdateCustomerVoucherDto>
    {
        
    }
}

