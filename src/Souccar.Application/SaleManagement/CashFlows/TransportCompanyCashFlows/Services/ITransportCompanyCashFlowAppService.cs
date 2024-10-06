using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.Settings.Currencies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public interface ITransportCompanyCashFlowAppService : IAsyncSouccarAppService<TransportCompanyCashFlowDto, int, FullPagedRequestDto, TransportCompanyCashFlowDto, TransportCompanyCashFlowDto>
    {
        Task<List<TransportCompanyCashFlowDto>> GetAllByTransportCompanyId(int TransportCompanyId, string fromDate, string toDate, Currency? currency);
        Task<BalanceInfoDto> GetBalance(int id);
    }
}
