using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Stocks.Dto;

namespace Souccar.SaleManagement.Stocks.Services
{
    public class StockHistoryAppService : AsyncSouccarAppService<StockHistory, StockHistoryDto, int, FullPagedRequestDto, CreateStockHistoryDto, UpdateStockHistoryDto>, IStockHistoryAppService
    {
        public StockHistoryAppService(IStockHistoryDomainService domainService) : base(domainService)
        {
        }
    }
}
