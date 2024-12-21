using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowDeleteEventHandler : IAsyncEventHandler<TransportCompanyCashFlowDeleteEventData>, ITransientDependency
    {
        private readonly ITransportCompanyCashFlowDomainService _transportCompanyCashFlowDomainService;

        public TransportCompanyCashFlowDeleteEventHandler(ITransportCompanyCashFlowDomainService transportCompanyCashFlowDomainService)
        {
            _transportCompanyCashFlowDomainService = transportCompanyCashFlowDomainService;
        }

        public async Task HandleEventAsync(TransportCompanyCashFlowDeleteEventData eventData)
        {
            var transportCompanyCashFlow = await _transportCompanyCashFlowDomainService.GetCashFlow(eventData.TransportCompanyId, eventData.RelatedId, eventData.TransactionName);
            if (transportCompanyCashFlow != null)
            {
                await _transportCompanyCashFlowDomainService.DeleteAsync(transportCompanyCashFlow.Id);
            }
        }
    }
}
