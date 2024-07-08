using Souccar.SaleManagement.Stocks.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Stocks.Services
{
    public interface IStockAppService : IAsyncSouccarAppService<StockDto, int, FullPagedRequestDto, CreateStockDto, UpdateStockDto>
    {
    }
}

