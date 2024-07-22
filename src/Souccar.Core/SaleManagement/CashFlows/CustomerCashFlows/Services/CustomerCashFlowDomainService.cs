using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services
{
    public class CustomerCashFlowDomainService : SouccarDomainService<CustomerCashFlow, int>, ICustomerCashFlowDomainService
    {
        private readonly IRepository<CustomerCashFlow> _customerCashFlowRepository;
        private readonly ICustomerDomainService _customerDomainService;

        public CustomerCashFlowDomainService(IRepository<CustomerCashFlow> customerCashFlowRepository, ICustomerDomainService customerDomainService = null) : base(customerCashFlowRepository)
        {
            _customerCashFlowRepository = customerCashFlowRepository;
            _customerDomainService = customerDomainService;
        }

        public async Task<CustomerCashFlow> GetByInfo(int? customerId, double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName)
        {
            return await _customerCashFlowRepository.FirstOrDefaultAsync(x =>
                x.CustomerId == customerId &&
                x.AmountDollar == amountDollar &&
                x.AmountDinar == amountDinar &&
                x.TransactionDetails == transactionDetails &&
                x.Note == note &&
                x.TransactionName == transactionName
            );
        }

        //public async Task<double> GetLastBalanceDinar(int? customerId)
        //{
        //    double balanceDinar = 0;
        //    var customerCashFlow = await _customerCashFlowRepository.GetAllListAsync(x => x.CustomerId == customerId);
        //    if (customerCashFlow.Any())
        //    {
        //        balanceDinar = customerCashFlow.OrderByDescending(x => x.CreationTime).Select(z => z.CurrentBalanceDinar).FirstOrDefault();
        //    }
        //    return balanceDinar;
        //}

        //public async Task<double> GetLastBalanceDollar(int? customerId)
        //{
        //    double balanceDollar = 0;
        //    var customerCashFlow = await _customerCashFlowRepository.GetAllListAsync(x => x.CustomerId == customerId);
        //    if (customerCashFlow.Any())
        //    {
        //        balanceDollar = customerCashFlow.OrderByDescending(x => x.CreationTime).Select(z => z.CurrentBalanceDollar).FirstOrDefault();
        //    }
        //    return balanceDollar;
        //}

        public async Task<double> GetLastBalance(int? transportCompanyId, Currency currency, DateTime toDate)
        {
            var transportCompanyBalance = await _customerDomainService.GetCustomerBalance(transportCompanyId, currency);

            var transportCompanyCashFlows = await _customerCashFlowRepository
            .GetAllListAsync(x => x.CustomerId == transportCompanyId && x.CreationTime <= toDate);

            if (transportCompanyCashFlows.Any())
            {
                if (currency == Currency.Dinar)
                {
                    transportCompanyBalance += transportCompanyCashFlows.Sum(x => x.AmountDinar);
                }
                else
                {
                    transportCompanyBalance += transportCompanyCashFlows.Sum(x => x.AmountDollar);
                }
            }

            return transportCompanyBalance;
        }
    }
}
