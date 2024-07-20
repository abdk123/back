using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public interface IClearanceCompanyCashFlowDomainService : ISouccarDomainService<ClearanceCompanyCashFlow, int>
    {
        //Task<double> GetLastBalanceDinar(int? clearanceCompanyId);
        //Task<double> GetLastBalanceDollar(int? clearanceCompanyId);
        Task<ClearanceCompanyCashFlow> GetByInfo(int? clearanceCompanyId,double amountDollar,double amountDinar,string transactionDetails,string note, TransactionName transactionName);
        Task<double> GetLastBalance(int? clearanceCompanyId, Currency currency, DateTime toDate);
    }
}
