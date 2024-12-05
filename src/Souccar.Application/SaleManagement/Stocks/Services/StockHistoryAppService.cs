using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Settings.Materials.Services;
using Souccar.SaleManagement.Stocks.Dto;
using System.Collections.Generic;
using System.Linq;


namespace Souccar.SaleManagement.Stocks.Services
{
    public class StockHistoryAppService : AsyncSouccarAppService<StockHistory, StockHistoryDto, int, FullPagedRequestDto, CreateStockHistoryDto, UpdateStockHistoryDto>, IStockHistoryAppService
    {
        private readonly IStockHistoryDomainService _stockHistoryDomainService;
        private readonly IMaterialDomainService _materialDomainService;
        public StockHistoryAppService(IStockHistoryDomainService domainService, IStockHistoryDomainService stockHistoryDomainService, IMaterialDomainService materialDomainService) : base(domainService)
        {
            _stockHistoryDomainService = stockHistoryDomainService;
            _materialDomainService = materialDomainService;
        }

        public IList<MaterialBalanceDto> GetMaterialBalance()
        {
            var materialBalances = new List<MaterialBalanceDto>();
            var logs = _stockHistoryDomainService.Get(include: new string[] { "Stock.Size" }).ToList();

            var materials = _materialDomainService.Get(include: new string[] { "Unit", "Stocks" }).ToList();
            foreach (var material in materials)
            {
                var materialBalance = new MaterialBalanceDto()
                {
                    MaterialId = material.Id,
                    UnitName = material.Unit.Name,
                    Name = material.Name,
                    Stocks = new List<StockBalanceDto>()
                };
                foreach (var stock in material.Stocks)
                {
                    var stockHistories = logs.Where(x => x.StockId == stock.Id);
                    if(stockHistories.Any())
                    {
                        var stockBalance = new StockBalanceDto()
                        {
                            SizeName = stock.Size.Name,
                            Price = stock.Price,
                            Quantity = stockHistories.Any() ? stockHistories.Sum(x => x.Quantity) : 0
                        };
                        stockBalance.NumberInSmallUnit = stockBalance.Quantity / stock.ConversionValue;

                        materialBalance.Stocks.Add(stockBalance);
                    }
                }
                materialBalances.Add(materialBalance);
            }
            return materialBalances;
        }

        public IList<StockHistoryDto>  GetByMaterialId(int materialId)
        {
            var include = new string[]
            {
                "Stock.Size",
                "Stock.Material"
            };
            var StockHistories = _stockHistoryDomainService.Get(filter:x=>x.Stock.MaterialId == materialId,include: include).ToList();
            return ObjectMapper.Map<List<StockHistoryDto>>(StockHistories);
        }

    }
}
