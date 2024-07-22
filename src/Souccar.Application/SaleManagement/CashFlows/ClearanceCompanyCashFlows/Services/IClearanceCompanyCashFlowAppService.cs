using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public interface IClearanceCompanyCashFlowAppService : IAsyncSouccarAppService<ClearanceCompanyCashFlowDto, int, FullPagedRequestDto, ClearanceCompanyCashFlowDto, ClearanceCompanyCashFlowDto>
    {
    }
}
