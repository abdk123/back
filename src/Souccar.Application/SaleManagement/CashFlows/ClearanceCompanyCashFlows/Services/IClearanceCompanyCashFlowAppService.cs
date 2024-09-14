using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public interface IClearanceCompanyCashFlowAppService : IAsyncSouccarAppService<ClearanceCompanyCashFlowDto, int, FullPagedRequestDto, ClearanceCompanyCashFlowDto, ClearanceCompanyCashFlowDto>
    {
        Task<List<ClearanceCompanyCashFlowDto>> GetAllByClearanceCompanyId(int clearanceCompanyId, string fromDate, string toDate);
        Task<BalanceInfoDto> GetBalance(int id);
    }
}
