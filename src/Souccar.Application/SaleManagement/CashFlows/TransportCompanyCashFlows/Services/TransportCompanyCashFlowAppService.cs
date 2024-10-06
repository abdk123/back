using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Souccar.SaleManagement.Settings.Currencies;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public class TransportCompanyCashFlowAppService :
        AsyncSouccarAppService<TransportCompanyCashFlow, TransportCompanyCashFlowDto, int, FullPagedRequestDto, TransportCompanyCashFlowDto, TransportCompanyCashFlowDto>, ITransportCompanyCashFlowAppService
    {
        private readonly ITransportCompanyCashFlowDomainService _transportCompanyCashFlowDomainService;

        public TransportCompanyCashFlowAppService(ITransportCompanyCashFlowDomainService transportCompanyCashFlowDomainService) : base(transportCompanyCashFlowDomainService)
        {
            _transportCompanyCashFlowDomainService = transportCompanyCashFlowDomainService;
        }

        public async Task<List<TransportCompanyCashFlowDto>> GetAllByTransportCompanyId(int transportCompanyId, string fromDate, string toDate, Currency? currency)
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
                 Task.FromResult(_transportCompanyCashFlowDomainService.GetAllWithIncluding("TransportCompany")
                 .Where(x => x.TransportCompanyId == transportCompanyId && x.CreationTime >= fromDateSearch && x.CreationTime <= toDateSearch));

            if (currency == Currency.Dollar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDollar != 0);
            }
            else if (currency == Currency.Dinar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDinar != 0);
            }
            return ObjectMapper.Map<List<TransportCompanyCashFlowDto>>(cashFlows);
        }
        public async Task<BalanceInfoDto> GetBalance(int id)
        {
            var dollarBalance = await _transportCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dollar, DateTime.Now);
            var dinarBalance = await _transportCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dinar, DateTime.Now);

            return new BalanceInfoDto(id, dollarBalance, dinarBalance);
        }
    
    }
}
