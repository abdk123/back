using Souccar.SaleManagement.Stocks.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Souccar.Core.Dto;
using System.Linq;
using System.Xml.Linq;
using Abp.Collections.Extensions;
using Souccar.SaleManagement.Settings.Materials;

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

        public IList<StockDto> GetAllByMaterialId(int materialId)
        {
            var stocks = _stockDomainService.GetAllWithIncluding("Material")
                .Where(x => x.MaterialId == materialId);
            if(stocks.Any())
            {
                return ObjectMapper.Map<List<StockDto>>(stocks.ToList());
            }
            return new List<StockDto>();
        }

        

        //public async Task<List<StockDto>> GetAllByMaterialIdAsync(int materialId)
        //{
        //    var stocks = await _stockDomainService.GetAllByMaterialIdAsync(materialId);
        //    return ObjectMapper.Map<List<StockDto>>(stocks);
        //}
    }
}

