using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services
{
    public class CustomerCashFlowAppService :
        AsyncSouccarAppService<CustomerCashFlow, CustomerCashFlowDto, int, FullPagedRequestDto, CustomerCashFlowDto, CustomerCashFlowDto>, ICustomerCashFlowAppService
    {
        private readonly ICustomerCashFlowDomainService _customerCashFlowDomainService;

        public CustomerCashFlowAppService(ICustomerCashFlowDomainService customerCashFlowDomainService) : base(customerCashFlowDomainService)
        {
            _customerCashFlowDomainService = customerCashFlowDomainService;
        }

        public async Task<List<CustomerCashFlowDto>> GetAllByCustomerId(int customerId)
        {
            var cashFlows = await
                 Task.FromResult(_customerCashFlowDomainService.GetAllWithIncluding("Customer")
                 .Where(x => x.CustomerId == customerId).ToList());
            return ObjectMapper.Map<List<CustomerCashFlowDto>>(cashFlows);
        }
    }
}
