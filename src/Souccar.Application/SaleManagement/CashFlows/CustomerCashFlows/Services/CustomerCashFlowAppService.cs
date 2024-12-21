using Abp.Domain.Uow;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers.Services;
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
        private readonly ICustomerDomainService _customerDomainService;

        public CustomerCashFlowAppService(ICustomerCashFlowDomainService customerCashFlowDomainService, ICustomerDomainService customerDomainService) : base(customerCashFlowDomainService)
        {
            _customerCashFlowDomainService = customerCashFlowDomainService;
            _customerDomainService = customerDomainService;
        }
        public async Task<List<CustomerCashFlowDto>> GetAllByCustomerId(int customerId,string fromDate,string toDate, Currency? currency)
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
                 Task.FromResult(_customerCashFlowDomainService.GetAllWithIncluding("Customer")
                 .Where(x => x.CustomerId == customerId && x.CreationTime >= fromDateSearch && x.CreationTime <= toDateSearch));


            if (currency == Currency.Dollar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDollar != 0);
                var dollarBalance = await _customerCashFlowDomainService
                .GetLastBalance(customerId, Currency.Dollar, DateTime.Now);

                var dtos = ObjectMapper.Map<List<CustomerCashFlowDto>>(cashFlows);
                return InitialDollarBalance(dtos,dollarBalance);
            }
            else if (currency == Currency.Dinar)
            {
                cashFlows = cashFlows.Where(x => x.AmountDinar != 0);
                var dinarBalance = await _customerCashFlowDomainService
                .GetLastBalance(customerId, Currency.Dinar, DateTime.Now);

                var dtos = ObjectMapper.Map<List<CustomerCashFlowDto>>(cashFlows);
                return InitialDinarBalance(dtos, dinarBalance);
            }
            
            return ObjectMapper.Map<List<CustomerCashFlowDto>>(cashFlows);
        }
        public async Task<BalanceInfoDto> GetBalance(int id)
        {
            var customer = await _customerDomainService.GetAsync(id);
            var dollarBalance = await _customerCashFlowDomainService
                .GetLastBalance(id, Currency.Dollar, DateTime.Now);
            var dinarBalance = await _customerCashFlowDomainService
                .GetLastBalance(id, Currency.Dinar, DateTime.Now);

            return new BalanceInfoDto(id, dollarBalance, dinarBalance,customer.FullName);
        }

        [UnitOfWork]
        public IList<BalanceInfoDto> GetAllBalances()
        {
            var balances = new List<BalanceInfoDto>();
            var customers =  _customerDomainService.GetAll().ToList();
            var cashFlows = _customerCashFlowDomainService.GetAll().ToList();
            foreach (var customer in customers)
            {
                var dinarBalance = 0.0;
                var dollarBalance = 0.0;
                if (cashFlows.Any())
                {
                    var customerCashFlows = cashFlows.Where(x => x.CustomerId == customer.Id);
                    if (customerCashFlows.Any())
                    {
                        dinarBalance += customerCashFlows.Sum(x => x.AmountDinar);
                        dollarBalance += customerCashFlows.Sum(x => x.AmountDollar);
                    }
                }
                balances.Add(new BalanceInfoDto(customer.Id, dollarBalance, dinarBalance, customer.FullName));
            }

            return balances;
        }
        private List<CustomerCashFlowDto> InitialDollarBalance(List<CustomerCashFlowDto> cashFlows, double lastBalance)
        {
            for (int i = cashFlows.Count - 1; i >= 0 ; i--)
            {
                if(i == cashFlows.Count - 1)
                {
                    cashFlows[i].CurrentBalanceDollar = lastBalance;
                }
                else
                {
                    cashFlows[i].CurrentBalanceDollar = lastBalance - cashFlows[i+1].AmountDollar;
                }
            }

            return cashFlows;
        }
        private List<CustomerCashFlowDto> InitialDinarBalance(List<CustomerCashFlowDto> cashFlows, double lastBalance)
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
