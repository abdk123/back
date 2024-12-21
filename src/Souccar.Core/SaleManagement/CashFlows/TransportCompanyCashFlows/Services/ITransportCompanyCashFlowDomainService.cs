using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public interface ITransportCompanyCashFlowDomainService : ISouccarDomainService<TransportCompanyCashFlow, int>
    {
        Task<TransportCompanyCashFlow> GetByInfo(int? transportCompanyId, double amountDollar, double amountDinar, string transactionDetails, TransactionName transactionName);
        Task<double> GetLastBalance(int? transportCompanyId, Currency currency, DateTime toDate);
        Task<TransportCompanyCashFlow> GetCashFlow(int? transportCompanyId, int? relatedId, TransactionName transactionName);

    }
}
