using Souccar.SaleManagement.Settings.Customers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerVoucherAppService :
        AsyncSouccarAppService<CustomerVoucher, CustomerVoucherDto, int, FullPagedRequestDto, CreateCustomerVoucherDto, UpdateCustomerVoucherDto>, ICustomerVoucherAppService
    {
        private readonly ICustomerVoucherDomainService _customerVoucherDomainService;
        public CustomerVoucherAppService(ICustomerVoucherDomainService customerVoucherDomainService) : base(customerVoucherDomainService)
        {
            _customerVoucherDomainService = customerVoucherDomainService;
        }
    }
}

