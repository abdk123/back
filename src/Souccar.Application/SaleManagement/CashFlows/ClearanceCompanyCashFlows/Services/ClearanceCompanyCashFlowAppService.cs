using Abp.Domain.Uow;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.Settings.Companies.Services;
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
        private readonly IClearanceCompanyDomainService _clearanceCompanyDomainService;

        public ClearanceCompanyCashFlowAppService(IClearanceCompanyCashFlowDomainService clearanceCompanyCashFlowDomainService, IClearanceCompanyDomainService clearanceCompanyDomainService) : base(clearanceCompanyCashFlowDomainService)
        {
            _clearanceCompanyCashFlowDomainService = clearanceCompanyCashFlowDomainService;
            _clearanceCompanyDomainService = clearanceCompanyDomainService;
        }

        public async Task<List<ClearanceCompanyCashFlowDto>> GetAllByClearanceCompanyId(int clearanceCompanyId, string fromDate, string toDate,Currency? currency)
        {
            var fromDateSearch = DateTime.Now;
            if (!string.IsNullOrEmpty(fromDate))
            {
                fromDateSearch = DateTime.Parse(fromDate);
            }
            fromDateSearch = new DateTime(fromDateSearch.Year, fromDateSearch.Month, fromDateSearch.Day, 0, 0, 0);

            var toDateSearch = DateTime.Now;
            if (!string.IsNullOrEmpty(toDate))
            {
                toDateSearch = DateTime.Parse(toDate);
            }
            toDateSearch = new DateTime(toDateSearch.Year, toDateSearch.Month, toDateSearch.Day, 23, 59, 59);

            var cashFlows = await
                 Task.FromResult(_clearanceCompanyCashFlowDomainService.GetAllWithIncluding("ClearanceCompany")
                 .Where(x => x.ClearanceCompanyId == clearanceCompanyId && x.CreationTime >= fromDateSearch && x.CreationTime <= toDateSearch));
            if (currency == Currency.Dollar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDollar != 0);
                var dollarBalance = await _clearanceCompanyCashFlowDomainService
                .GetLastBalance(clearanceCompanyId, Currency.Dollar, DateTime.Now);

                var dtos = ObjectMapper.Map<List<ClearanceCompanyCashFlowDto>>(cashFlows);
                return InitialDollarBalance(dtos, dollarBalance);
            }
            else if (currency == Currency.Dinar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDinar != 0);
                var dinarBalance = await _clearanceCompanyCashFlowDomainService
                .GetLastBalance(clearanceCompanyId, Currency.Dinar, DateTime.Now);

                var dtos = ObjectMapper.Map<List<ClearanceCompanyCashFlowDto>>(cashFlows);
                return InitialDinarBalance(dtos, dinarBalance);
            }

            return ObjectMapper.Map<List<ClearanceCompanyCashFlowDto>>(cashFlows);
        }

        [UnitOfWork]
        public IList<BalanceInfoDto> GetAllBalances()
        {
            var balances = new List<BalanceInfoDto>();
            var clearanceCompanys = _clearanceCompanyDomainService.GetAll().ToList();
            var cashFlows = _clearanceCompanyCashFlowDomainService.GetAll().ToList();
            foreach (var clearanceCompany in clearanceCompanys)
            {
                var dinarBalance = 0.0;
                var dollarBalance = 0.0;
                if (cashFlows.Any())
                {
                    var clearanceCompanyCashFlows = cashFlows.Where(x => x.ClearanceCompanyId == clearanceCompany.Id);
                    if (clearanceCompanyCashFlows.Any())
                    {
                        dinarBalance += clearanceCompanyCashFlows.Sum(x => x.AmountDinar);
                        dollarBalance += clearanceCompanyCashFlows.Sum(x => x.AmountDollar);
                    }
                }
                balances.Add(new BalanceInfoDto(clearanceCompany.Id, dollarBalance, dinarBalance, clearanceCompany.Name));
            }

            return balances;
        }

        public async Task<BalanceInfoDto> GetBalance(int id)
        {
            var company = await _clearanceCompanyDomainService.GetAsync(id);
            var dollarBalance = await _clearanceCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dollar, DateTime.Now);
            var dinarBalance = await _clearanceCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dinar, DateTime.Now);

            return new BalanceInfoDto(id, dollarBalance, dinarBalance, company.Name);
        }

        private List<ClearanceCompanyCashFlowDto> InitialDollarBalance(List<ClearanceCompanyCashFlowDto> cashFlows, double lastBalance)
        {
            for (int i = cashFlows.Count - 1; i >= 0; i--)
            {
                if (i == cashFlows.Count - 1)
                {
                    cashFlows[i].CurrentBalanceDollar = lastBalance;
                }
                else
                {
                    cashFlows[i].CurrentBalanceDollar = lastBalance - cashFlows[i + 1].AmountDollar;
                }
            }

            return cashFlows;
        }

        private List<ClearanceCompanyCashFlowDto> InitialDinarBalance(List<ClearanceCompanyCashFlowDto> cashFlows, double lastBalance)
        {
            for (int i = cashFlows.Count - 1; i >= 0; i--)
            {
                if (i == cashFlows.Count - 1)
                {
                    cashFlows[i].CurrentBalanceDinar = lastBalance;
                }
                else
                {
                    cashFlows[i].CurrentBalanceDinar = lastBalance - cashFlows[i + 1].AmountDinar;
                }
            }

            return cashFlows;
        }

    }
}
