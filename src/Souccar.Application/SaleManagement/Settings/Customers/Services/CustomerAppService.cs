using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Settings.Customers.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerAppService :
        AsyncSouccarAppService<Customer, CustomerDto, int, FullPagedRequestDto, CreateCustomerDto, UpdateCustomerDto>, ICustomerAppService
    {
        private readonly ICustomerDomainService _customerDomainService;
        public CustomerAppService(ICustomerDomainService customerDomainService) : base(customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }
    }
}

