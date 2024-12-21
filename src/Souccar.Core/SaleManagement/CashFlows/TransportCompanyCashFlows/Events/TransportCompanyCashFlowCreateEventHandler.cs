using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services;
using System.Threading.Tasks;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;

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
            var cashFlow = await _transportCompanyCashFlowDomainService.GetCashFlow(eventData.TransportCompanyId, eventData.RelatedId, eventData.TransactionName);
            if (cashFlow != null)
            {
                cashFlow.RelatedId = eventData.RelatedId;
                cashFlow.AmountDinar = eventData.AmountDinar;
                cashFlow.AmountDollar = eventData.AmountDollar;
                cashFlow.TransportCompanyId = eventData.TransportCompanyId;
                cashFlow.TransactionName = eventData.TransactionName;
                cashFlow.TransactionDetails = eventData.TransactionDetails;
                await _transportCompanyCashFlowDomainService.UpdateAsync(cashFlow);
            }
            else
            {
                var transportCompanyCashFlow = new TransportCompanyCashFlow()
                {
                    RelatedId = eventData.RelatedId,
                    AmountDinar = eventData.AmountDinar,
                    AmountDollar = eventData.AmountDollar,
                    TransportCompanyId = eventData.TransportCompanyId,
                    TransactionName = eventData.TransactionName,
                    TransactionDetails = eventData.TransactionDetails,
                };
                await _transportCompanyCashFlowDomainService.InsertAsync(transportCompanyCashFlow);
            }
        }
    }
}
