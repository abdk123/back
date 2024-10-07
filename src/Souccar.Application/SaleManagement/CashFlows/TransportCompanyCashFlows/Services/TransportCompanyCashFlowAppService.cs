using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;
using Souccar.SaleManagement.Settings.Companies.Services;
using Abp.Domain.Uow;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public class TransportCompanyCashFlowAppService :
        AsyncSouccarAppService<TransportCompanyCashFlow, TransportCompanyCashFlowDto, int, FullPagedRequestDto, TransportCompanyCashFlowDto, TransportCompanyCashFlowDto>, ITransportCompanyCashFlowAppService
    {
        private readonly ITransportCompanyCashFlowDomainService _transportCompanyCashFlowDomainService;
        private readonly ITransportCompanyDomainService _transportCompanyDomainService;

        public TransportCompanyCashFlowAppService(ITransportCompanyCashFlowDomainService transportCompanyCashFlowDomainService, ITransportCompanyDomainService transportCompanyDomainService) : base(transportCompanyCashFlowDomainService)
        {
            _transportCompanyCashFlowDomainService = transportCompanyCashFlowDomainService;
            _transportCompanyDomainService = transportCompanyDomainService;
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
                var dollarBalance = await _transportCompanyCashFlowDomainService
                .GetLastBalance(transportCompanyId, Currency.Dollar, DateTime.Now);

                var dtos = ObjectMapper.Map<List<TransportCompanyCashFlowDto>>(cashFlows);
                return InitialDollarBalance(dtos, dollarBalance);
            }
            else if (currency == Currency.Dinar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDinar != 0);
                var dinarBalance = await _transportCompanyCashFlowDomainService
                .GetLastBalance(transportCompanyId, Currency.Dinar, DateTime.Now);

                var dtos = ObjectMapper.Map<List<TransportCompanyCashFlowDto>>(cashFlows);
                return InitialDinarBalance(dtos, dinarBalance);
            }

            return ObjectMapper.Map<List<TransportCompanyCashFlowDto>>(cashFlows);
        }

        [UnitOfWork]
        public IList<BalanceInfoDto> GetAllBalances()
        {
            var balances = new List<BalanceInfoDto>();
            var transportCompanys = _transportCompanyDomainService.GetAll().ToList();
            var cashFlows = _transportCompanyCashFlowDomainService.GetAll().ToList();
            foreach (var transportCompany in transportCompanys)
            {
                var dinarBalance = transportCompany.BalanceInDinar;
                var dollarBalance = transportCompany.BalanceInDollar;
                if (cashFlows.Any())
                {
                    var transportCompanyCashFlows = cashFlows.Where(x => x.TransportCompanyId == transportCompany.Id);
                    if (transportCompanyCashFlows.Any())
                    {
                        dinarBalance += transportCompanyCashFlows.Sum(x => x.AmountDinar);
                        dollarBalance += transportCompanyCashFlows.Sum(x => x.AmountDollar);
                    }
                }
                balances.Add(new BalanceInfoDto(transportCompany.Id, dollarBalance, dinarBalance, transportCompany.Name));
            }

            return balances;
        }

        public async Task<BalanceInfoDto> GetBalance(int id)
        {
            var company = await _transportCompanyDomainService.GetAsync(id);
            var dollarBalance = await _transportCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dollar, DateTime.Now);
            var dinarBalance = await _transportCompanyCashFlowDomainService
                .GetLastBalance(id, Currency.Dinar, DateTime.Now);

            return new BalanceInfoDto(id, dollarBalance, dinarBalance, company.Name);
        }

        private List<TransportCompanyCashFlowDto> InitialDollarBalance(List<TransportCompanyCashFlowDto> cashFlows, double lastBalance)
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

        private List<TransportCompanyCashFlowDto> InitialDinarBalance(List<TransportCompanyCashFlowDto> cashFlows, double lastBalance)
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
