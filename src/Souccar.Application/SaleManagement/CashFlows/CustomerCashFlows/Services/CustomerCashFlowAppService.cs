using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.Settings.Currencies;
using System;
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

        public async Task<List<CustomerCashFlowDto>> GetAllByCustomerId(int customerId,string fromDate,string toDate)
        {
            var fromDateSearch = DateTime.Now;
            if (!string.IsNullOrEmpty(fromDate))
            {
                fromDateSearch = DateTime.Parse(fromDate);
            }
            fromDateSearch = new DateTime(fromDateSearch.Year, fromDateSearch.Month, fromDateSearch.Day, 12, 0, 0);

            var toDateSearch = DateTime.Now;
            if (!string.IsNullOrEmpty(toDate))
            {
                toDateSearch = DateTime.Parse(toDate);
            }
            toDateSearch = new DateTime(toDateSearch.Year, toDateSearch.Month, toDateSearch.Day, 23, 59, 59);

            var cashFlows = await
                 Task.FromResult(_customerCashFlowDomainService.GetAllWithIncluding("Customer")
                 .Where(x => x.CustomerId == customerId && x.CreationTime >= fromDateSearch && x.CreationTime <= toDateSearch).ToList());
            return ObjectMapper.Map<List<CustomerCashFlowDto>>(cashFlows);
        }
        public async Task<BalanceInfoDto> GetBalance(int id)
        {
            var dollarBalance = await _customerCashFlowDomainService
                .GetLastBalance(id, Currency.Dollar, DateTime.Now);
            var dinarBalance = await _customerCashFlowDomainService
                .GetLastBalance(id, Currency.Dinar, DateTime.Now);

            return new BalanceInfoDto(id, dollarBalance, dinarBalance);
        }
    }
}
