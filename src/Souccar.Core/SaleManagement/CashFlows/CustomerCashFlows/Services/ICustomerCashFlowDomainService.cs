using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services
{
    public interface ICustomerCashFlowDomainService : ISouccarDomainService<CustomerCashFlow, int>
    {
        //Task<double> GetLastBalanceDinar(int? customerId);
        //Task<double> GetLastBalanceDollar(int? customerId);
        Task<CustomerCashFlow> GetByInfo(int? customerId, double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName);
        Task<double> GetLastBalance(int? transportCompanyId, Currency currency, DateTime toDate);
    }
}
