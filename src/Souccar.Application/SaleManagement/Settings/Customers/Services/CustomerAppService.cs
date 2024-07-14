using Souccar.Core.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Settings.Customers.Dto;
using System.Collections.Generic;
using System.Linq;

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

        public IList<DropdownDto> GetForDropdownAsync()
        {
            var entities = _customerDomainService.GetAll();
            if (entities.Any())
                return ObjectMapper.Map<List<DropdownDto>>(entities.ToList());

            return new List<DropdownDto>();
        }
    }
}

