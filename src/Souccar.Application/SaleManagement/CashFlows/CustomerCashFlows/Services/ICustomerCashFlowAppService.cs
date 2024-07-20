using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services
{
    public interface ICustomerCashFlowAppService : IAsyncSouccarAppService<CustomerCashFlowDto, int, FullPagedRequestDto, CustomerCashFlowDto, CustomerCashFlowDto>
    {
    }
}
