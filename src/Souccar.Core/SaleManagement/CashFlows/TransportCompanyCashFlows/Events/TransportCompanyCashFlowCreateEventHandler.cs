using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services;
using System.Threading.Tasks;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using Souccar.SaleManagement.Settings.Currencies;
using System;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowCreateEventHandler : IAsyncEventHandler<TransportCompanyCashFlowCreateEventData>, ITransientDependency
    {
        private readonly ITransportCompanyCashFlowDomainService _transportCompanyCashFlowDomainService;

        public TransportCompanyCashFlowCreateEventHandler(ITransportCompanyCashFlowDomainService transportCompanyCashFlowDomainService)
        {
            _transportCompanyCashFlowDomainService = transportCompanyCashFlowDomainService;
        }

        public async Task HandleEventAsync(TransportCompanyCashFlowCreateEventData eventData)
        {
            double newCurrentBalanceDinar = 0;
            double newCurrentBalanceDollar = 0;

            var oldCurrentBalanceDinar = await _transportCompanyCashFlowDomainService.GetLastBalance(eventData.TransportCompanyId, Currency.Dinar, DateTime.Now);
            var oldCurrentBalanceDollar = await _transportCompanyCashFlowDomainService.GetLastBalance(eventData.TransportCompanyId, Currency.Dollar, DateTime.Now);

            if (eventData.TransactionName == TransactionName.Spend)
            {
                newCurrentBalanceDinar = oldCurrentBalanceDinar - eventData.AmountDinar;
                newCurrentBalanceDollar = oldCurrentBalanceDollar - eventData.AmountDollar;
            }
            else if (eventData.TransactionName == TransactionName.Receive)
            {
                newCurrentBalanceDinar = oldCurrentBalanceDinar + eventData.AmountDinar;
                newCurrentBalanceDollar = oldCurrentBalanceDollar + eventData.AmountDollar;
            }

            var transportCompanyCashFlow = new TransportCompanyCashFlow()
            {
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
