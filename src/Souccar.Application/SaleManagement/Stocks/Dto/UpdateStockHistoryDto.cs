using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Stocks.Dto
{
    public class UpdateStockHistoryDto : CreateStockHistoryDto, IEntityDto
    {
        public int Id { get; set; }
    }
}
