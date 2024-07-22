using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public class TransportCompanyCashFlowAppService :
        AsyncSouccarAppService<TransportCompanyCashFlow, TransportCompanyCashFlowDto, int, FullPagedRequestDto, TransportCompanyCashFlowDto, TransportCompanyCashFlowDto>, ITransportCompanyCashFlowAppService
    {
        private readonly ITransportCompanyCashFlowDomainService _transportCompanyCashFlowDomainService;

        public TransportCompanyCashFlowAppService(ITransportCompanyCashFlowDomainService transportCompanyCashFlowDomainService) : base(transportCompanyCashFlowDomainService)
        {
            _transportCompanyCashFlowDomainService = transportCompanyCashFlowDomainService;
        }
    }
}
