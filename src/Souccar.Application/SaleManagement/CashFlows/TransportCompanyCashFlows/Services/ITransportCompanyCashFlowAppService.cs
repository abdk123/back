using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public interface ITransportCompanyCashFlowAppService : IAsyncSouccarAppService<TransportCompanyCashFlowDto, int, FullPagedRequestDto, TransportCompanyCashFlowDto, TransportCompanyCashFlowDto>
    {
    }
}
