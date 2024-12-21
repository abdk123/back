using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public interface IClearanceCompanyCashFlowDomainService : ISouccarDomainService<ClearanceCompanyCashFlow, int>
    {
        Task<ClearanceCompanyCashFlow> GetByInfo(int? clearanceCompanyId,double amountDollar,double amountDinar,string transactionDetails,TransactionName transactionName);
        Task<double> GetLastBalance(int? clearanceCompanyId, Currency currency, DateTime toDate);
        Task<ClearanceCompanyCashFlow> GetCashFlow(int? id, int? relatedId, TransactionName transactionName);
    }
}
