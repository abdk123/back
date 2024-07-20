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

        public async Task<TransportCompanyCashFlow> GetByInfo(int? transportCompanyId, double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName)
        {
            return await _transportCompanyCashFlowRepository.FirstOrDefaultAsync(x =>
                x.TransportCompanyId == transportCompanyId &&
                x.AmountDollar == amountDollar &&
                x.AmountDinar == amountDinar &&
                x.TransactionDetails == transactionDetails &&
                x.Note == note &&
                x.TransactionName == transactionName
            );
        }

        //public async Task<double> GetLastBalanceDinar(int? transportCompanyId)
        //{
        //    double balanceDinar = 0;
        //    var transportCompanyCashFlow = await _transportCompanyCashFlowRepository.GetAllListAsync(x => x.TransportCompanyId == transportCompanyId);
        //    if (transportCompanyCashFlow.Any())
        //    {
        //        balanceDinar = transportCompanyCashFlow.OrderByDescending(x => x.CreationTime).Select(z => z.CurrentBalanceDinar).FirstOrDefault();
        //    }
        //    return balanceDinar;
        //}

        //public async Task<double> GetLastBalanceDollar(int? transportCompanyId)
        //{
        //    double balanceDollar = 0;
        //    var transportCompanyCashFlow = await _transportCompanyCashFlowRepository.GetAllListAsync(x => x.TransportCompanyId == transportCompanyId);
        //    if (transportCompanyCashFlow.Any())
        //    {
        //        balanceDollar = transportCompanyCashFlow.OrderByDescending(x => x.CreationTime).Select(z => z.CurrentBalanceDollar).FirstOrDefault();
        //    }
        //    return balanceDollar;
        //}

        public async Task<double> GetLastBalance(int? transportCompanyId, Currency currency, DateTime toDate)
        {
            var transportCompanyBalance = await _transportCompanyDomainService.GetTransportCompanyBalance(transportCompanyId, currency);

            var transportCompanyCashFlows = await _transportCompanyCashFlowRepository
            .GetAllListAsync(x => x.TransportCompanyId == transportCompanyId && x.CreationTime <= toDate);

            if (transportCompanyCashFlows.Any())
            {
                if (currency == Currency.Dinar)
                {
                    transportCompanyBalance += transportCompanyCashFlows.Sum(x => x.CurrentBalanceDinar);
                }
                else
                {
                    transportCompanyBalance += transportCompanyCashFlows.Sum(x => x.CurrentBalanceDollar);
                }
            }

            return transportCompanyBalance;
        }
    }
}
