using Souccar.SaleManagement.Stocks.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Stocks.Services
{
    public class StockAppService :
        AsyncSouccarAppService<Stock, StockDto, int, FullPagedRequestDto, CreateStockDto, UpdateStockDto>, IStockAppService
    {
        private readonly IStockDomainService _stockDomainService;
        public StockAppService(IStockDomainService stockDomainService) : base(stockDomainService)
        {
            _stockDomainService = stockDomainService;
        }
    }
}

