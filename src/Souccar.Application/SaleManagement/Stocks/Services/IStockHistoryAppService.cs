using Souccar.Core.Services;
using Souccar.Core.Dto.PagedRequests;
using Souccar.SaleManagement.Stocks.Dto;

namespace Souccar.SaleManagement.Stocks.Services
{
    public interface IStockHistoryAppService : IAsyncSouccarAppService<StockHistoryDto, int, FullPagedRequestDto, CreateStockHistoryDto, UpdateStockHistoryDto>
    {
        
    }
}

