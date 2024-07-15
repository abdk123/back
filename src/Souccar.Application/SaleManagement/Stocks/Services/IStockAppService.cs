using Souccar.SaleManagement.Stocks.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Stocks.Services
{
    public interface IStockAppService : IAsyncSouccarAppService<StockDto, int, FullPagedRequestDto, CreateStockDto, UpdateStockDto>
    {
        IList<MaterialUnitDto> GetMaterialUnits(int materialId);
        IList<StockDto> GetAllByMaterialId(int materialId);
        //Task<List<StockDto>> GetAllByMaterialIdAsync(int materialId);
    }
}

