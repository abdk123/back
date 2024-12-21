using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows;
using Souccar.SaleManagement.Settings.Companies.Services;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public class TransportCompanyCashFlowDomainService : SouccarDomainService<TransportCompanyCashFlow, int>, ITransportCompanyCashFlowDomainService
    {
        private readonly IRepository<TransportCompanyCashFlow> _transportCompanyCashFlowRepository;
        private readonly ITransportCompanyDomainService _transportCompanyDomainService;

        public TransportCompanyCashFlowDomainService(IRepository<TransportCompanyCashFlow> transportCompanyCashFlowRepository, ITransportCompanyDomainService transportCompanyDomainService = null) : base(transportCompanyCashFlowRepository)
        {
            _transportCompanyCashFlowRepository = transportCompanyCashFlowRepository;
            _transportCompanyDomainService = transportCompanyDomainService;
        }

        public async Task<TransportCompanyCashFlow> GetByInfo(int? transportCompanyId, double amountDollar, double amountDinar, string transactionDetails, TransactionName transactionName)
        {
            return await _transportCompanyCashFlowRepository.FirstOrDefaultAsync(x =>
                x.TransportCompanyId == transportCompanyId &&
                x.AmountDollar == amountDollar &&
                x.AmountDinar == amountDinar &&
                x.TransactionDetails == transactionDetails &&
                x.TransactionName == transactionName
            );
        }

        public async Task<TransportCompanyCashFlow> GetCashFlow(int? transportCompanyId, int? relatedId, TransactionName transactionName)
        {
            return await _transportCompanyCashFlowRepository.FirstOrDefaultAsync(x =>
                x.TransportCompanyId == transportCompanyId &&
                x.RelatedId == relatedId &&
                x.TransactionName == transactionName
            );
        }

        public async Task<double> GetLastBalance(int? transportCompanyId, Currency currency, DateTime toDate)
        {
            var transportCompanyBalance = 0.0;

            var transportCompanyCashFlows = await _transportCompanyCashFlowRepository
            .GetAllListAsync(x => x.TransportCompanyId == transportCompanyId && x.CreationTime <= toDate);

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
