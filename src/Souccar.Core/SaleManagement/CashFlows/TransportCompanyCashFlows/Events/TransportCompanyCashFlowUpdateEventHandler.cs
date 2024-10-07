using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowUpdateEventHandler : IAsyncEventHandler<TransportCompanyCashFlowUpdateEventData>, ITransientDependency
    {
        private readonly ITransportCompanyCashFlowDomainService _transportCompanyCashFlowDomainService;

        public TransportCompanyCashFlowUpdateEventHandler(ITransportCompanyCashFlowDomainService transportCompanyCashFlowDomainService)
        {
            _transportCompanyCashFlowDomainService = transportCompanyCashFlowDomainService;
        }

        public async Task HandleEventAsync(TransportCompanyCashFlowUpdateEventData eventData)
        {
            var cashFlow = await _transportCompanyCashFlowDomainService.
                FirstOrDefaultAsync(x=>x.RelatedId == eventData.RelatedId && x.TransactionName == eventData.TransactionName);
            
            if(cashFlow != null)
            {
                await _transportCompanyCashFlowDomainService.DeleteAsync(cashFlow.Id);
            }

            double newCurrentBalanceDinar = 0;
            double newCurrentBalanceDollar = 0;

            var oldCurrentBalanceDinar = await _transportCompanyCashFlowDomainService.GetLastBalance(eventData.TransportCompanyId, Currency.Dinar, DateTime.Now);
            var oldCurrentBalanceDollar = await _transportCompanyCashFlowDomainService.GetLastBalance(eventData.TransportCompanyId, Currency.Dollar, DateTime.Now);

            newCurrentBalanceDinar = oldCurrentBalanceDinar + eventData.AmountDinar;
            newCurrentBalanceDollar = oldCurrentBalanceDollar + eventData.AmountDollar;

            var transportCompanyCashFlow = new TransportCompanyCashFlow()
            {
                RelatedId = eventData.RelatedId,
                AmountDinar = eventData.AmountDinar,
                AmountDollar = eventData.AmountDollar,
                TransportCompanyId = eventData.TransportCompanyId,
                CurrentBalanceDinar = newCurrentBalanceDinar,
                CurrentBalanceDollar = newCurrentBalanceDollar,
                Note = eventData.Note,
                TransactionName = eventData.TransactionName,
                TransactionDetails = eventData.TransactionDetails,
            };

            await _transportCompanyCashFlowDomainService.InsertAsync(transportCompanyCashFlow);
        }

        
    }
}
