using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows;
using Souccar.SaleManagement.Settings.Companies.Services;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public class ClearanceCompanyCashFlowDomainService : SouccarDomainService<ClearanceCompanyCashFlow, int>, IClearanceCompanyCashFlowDomainService
    {
        private readonly IRepository<ClearanceCompanyCashFlow> _clearanceCompanyCashFlowRepository;
        private readonly IClearanceCompanyDomainService _clearanceCompanyDomainService;

        public ClearanceCompanyCashFlowDomainService(IRepository<ClearanceCompanyCashFlow> clearanceCompanyCashFlowRepository, IClearanceCompanyDomainService clearanceCompanyDomainService = null) : base(clearanceCompanyCashFlowRepository)
        {
            _clearanceCompanyCashFlowRepository = clearanceCompanyCashFlowRepository;
            _clearanceCompanyDomainService = clearanceCompanyDomainService;
        }

        public async Task<ClearanceCompanyCashFlow> GetByInfo(int? clearanceCompanyId, double amountDollar, double amountDinar, string transactionDetails, TransactionName transactionName)
        {
            return await _clearanceCompanyCashFlowRepository.FirstOrDefaultAsync(x =>
                x.ClearanceCompanyId == clearanceCompanyId &&
                x.AmountDollar == amountDollar &&
                x.AmountDinar == amountDinar &&
                x.TransactionDetails == transactionDetails &&
                x.TransactionName == transactionName
            );
        }

        public async Task<double> GetLastBalance(int? clearanceCompanyId, Currency currency, DateTime toDate)
        {
            var clearanceCompanyBalance = 0.0;

            var clearanceCompanyCashFlows = await _clearanceCompanyCashFlowRepository
            .GetAllListAsync(x => x.ClearanceCompanyId == clearanceCompanyId && x.CreationTime <= toDate);

            if (clearanceCompanyCashFlows.Any())
            {
                if (currency == Currency.Dinar)
                {
                    clearanceCompanyBalance += clearanceCompanyCashFlows.Sum(x => x.AmountDinar);
                }
                else
                {
                    clearanceCompanyBalance += clearanceCompanyCashFlows.Sum(x => x.AmountDollar);
                }
            }

            return clearanceCompanyBalance;
        }

        public async Task<ClearanceCompanyCashFlow> GetCashFlow(int? id, int? relatedId, TransactionName transactionName)
        {
            return await _clearanceCompanyCashFlowRepository.FirstOrDefaultAsync(x =>
                x.ClearanceCompanyId == id &&
                x.RelatedId == relatedId &&
                x.TransactionName == transactionName
            );
        }
    }
}
