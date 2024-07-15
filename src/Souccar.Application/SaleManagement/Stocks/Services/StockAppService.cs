using Souccar.SaleManagement.Stocks.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            var stocks = _stockDomainService.GetAll()
                .Where(x => x.MaterialId == materialId);
            if(stocks.Any())
            {
                return ObjectMapper.Map<List<StockDto>>(stocks.ToList());
            }
            return new List<StockDto>();
        }

        public IList<MaterialUnitDto> GetMaterialUnits(int materialId)
        {
            var list = new List<MaterialUnitDto>();
            var stocks = _stockDomainService.GetAllWithIncluding("Size,Unit").ToList()
                .Where(x => x.MaterialId == materialId);
            if (stocks.Any())
            {
                var units = stocks.Select(x => x.Unit);
                if (units.Any())
                {
                    list.AddRange(units.Select(x => new MaterialUnitDto(x.Id, x.Name, false)));
                }
                var sizes = stocks.Select(x => x.Size);
                if (sizes.Any())
                {
                    foreach (var size in sizes)
                    {
                        list.Add(new MaterialUnitDto(size.Id, size.Name, true));
                    }
                }
            }

            return list;
        }
    }
}

