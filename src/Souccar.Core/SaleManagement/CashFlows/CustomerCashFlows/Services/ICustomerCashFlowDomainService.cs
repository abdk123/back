using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services
{
    public interface ICustomerCashFlowDomainService : ISouccarDomainService<CustomerCashFlow, int>
    {
        Task<CustomerCashFlow> GetByInfo(int? customerId, double amountDollar, double amountDinar, string transactionDetails, TransactionName transactionName);
        Task<double> GetLastBalance(int? customerId, Currency currency, DateTime toDate);
        Task<CustomerCashFlow> GetCashFlow(int? customerId, int? relatedId, TransactionName transactionName);
    }
}
