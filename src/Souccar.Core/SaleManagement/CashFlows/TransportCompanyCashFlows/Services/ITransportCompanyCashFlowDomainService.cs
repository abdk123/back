using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public interface ITransportCompanyCashFlowDomainService : ISouccarDomainService<TransportCompanyCashFlow, int>
    {
        //Task<double> GetLastBalanceDinar(int? transportCompanyId);
        //Task<double> GetLastBalanceDollar(int? transportCompanyId);
        Task<TransportCompanyCashFlow> GetByInfo(int? transportCompanyId, double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName);
        Task<double> GetLastBalance(int? transportCompanyId, Currency currency, DateTime toDate);
    }
}
