using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Settings.Customers.Dto;
using System.Threading.Tasks;

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

        //public override Task<CustomerDto> CreateAsync(CreateCustomerDto input)
        //{
        //    var customer = ObjectMapper.Map<Customer>(input);
        //    customer.Type = input.Type;
        //}
    }
}

