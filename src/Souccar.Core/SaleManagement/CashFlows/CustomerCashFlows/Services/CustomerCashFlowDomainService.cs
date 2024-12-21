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

        public async Task<CustomerCashFlow> GetCashFlow(int? customerId, int? relatedId, TransactionName transactionName)
        {
            return await _customerCashFlowRepository.FirstOrDefaultAsync(x =>
                x.CustomerId == customerId &&
                x.RelatedId == relatedId &&
                x.TransactionName == transactionName
            );
        }

        public async Task<CustomerCashFlow> GetByInfo(int? customerId, double amountDollar, double amountDinar, string transactionDetails, TransactionName transactionName)
        {
            return await _customerCashFlowRepository.FirstOrDefaultAsync(x =>
                x.CustomerId == customerId &&
                x.AmountDollar == amountDollar &&
                x.AmountDinar == amountDinar &&
                x.TransactionDetails == transactionDetails &&
                x.TransactionName == transactionName
            );
        }

        public async Task<double> GetLastBalance(int? customerId, Currency currency, DateTime toDate)
        {
            var customerBalance = 0.0;

            var customerCashFlows = await _customerCashFlowRepository
            .GetAllListAsync(x => x.CustomerId == customerId && x.CreationTime <= toDate);

            if (customerCashFlows.Any())
            {
                if (currency == Currency.Dinar)
                {
                    customerBalance += customerCashFlows.Sum(x => x.AmountDinar);
                }
                else
                {
                    customerBalance += customerCashFlows.Sum(x => x.AmountDollar);
                }
            }

            return customerBalance;
        }

    }
}
