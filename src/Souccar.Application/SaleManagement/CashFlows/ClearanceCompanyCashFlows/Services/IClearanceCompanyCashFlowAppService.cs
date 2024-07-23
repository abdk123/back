using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public interface IClearanceCompanyCashFlowAppService : IAsyncSouccarAppService<ClearanceCompanyCashFlowDto, int, FullPagedRequestDto, ClearanceCompanyCashFlowDto, ClearanceCompanyCashFlowDto>
    {
        Task<List<ClearanceCompanyCashFlowDto>> GetAllByClearanceCompanyId(int clearanceCompanyId);
    }
}
