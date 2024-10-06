using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public class ClearanceCompanyCashFlowAppService :
        AsyncSouccarAppService<ClearanceCompanyCashFlow, ClearanceCompanyCashFlowDto, int, FullPagedRequestDto, ClearanceCompanyCashFlowDto, ClearanceCompanyCashFlowDto>, IClearanceCompanyCashFlowAppService
    {
        private readonly IClearanceCompanyCashFlowDomainService _clearanceCompanyCashFlowDomainService;

        public ClearanceCompanyCashFlowAppService(IClearanceCompanyCashFlowDomainService clearanceCompanyCashFlowDomainService) : base(clearanceCompanyCashFlowDomainService)
        {
            _clearanceCompanyCashFlowDomainService = clearanceCompanyCashFlowDomainService;
        }

        public async Task<List<ClearanceCompanyCashFlowDto>> GetAllByClearanceCompanyId(int clearanceCompanyId, string fromDate, string toDate,Currency? currency)
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
                 Task.FromResult(_clearanceCompanyCashFlowDomainService.GetAllWithIncluding("ClearanceCompany")
                 .Where(x => x.ClearanceCompanyId == clearanceCompanyId && x.CreationTime >= fromDateSearch && x.CreationTime <= toDateSearch));
            var afat = cashFlows.ToList();
            if (currency == Currency.Dollar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDollar !=0);
            }
            else if (currency == Currency.Dinar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDinar != 0);
            }
            
            return ObjectMapper.Map<List<ClearanceCompanyCashFlowDto>>(cashFlows.ToList());
        }

        public async Task<BalanceInfoDto> GetBalance(int id)
        {
            var dollarBalance = await _clearanceCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dollar, DateTime.Now);
            var dinarBalance = await _clearanceCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dinar, DateTime.Now);

            return new BalanceInfoDto(id, dollarBalance, dinarBalance);
        }

    }
}
