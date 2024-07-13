using Souccar.SaleManagement.Stocks.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<List<StockDto>> GetAllByMaterialIdAsync(int materialId)
        {
            var stocks = await _stockDomainService.GetAllByMaterialIdAsync(materialId);
            return ObjectMapper.Map<List<StockDto>>(stocks);
        }
    }
}

