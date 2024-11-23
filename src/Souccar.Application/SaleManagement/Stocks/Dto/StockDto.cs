using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Stores.Dto;
using Souccar.SaleManagement.Settings.Units.Dto;

namespace Souccar.SaleManagement.Stocks.Dto
{
    public class StockDto : EntityDto<int>
    {
        public string Barcode { get; set; }
        public string Note { get; set; }
        public double ConversionValue { get; set; }
        public double Quantity { get; set; }
        public double NumberInSmallUnit { get; set; }
        public int? SizeId { get; set; }
        public int? MaterialId { get; set; }
        public string Material { get; set; }
        public int? StoreId { get; set; }
        public StoreDto Store { get; set; }
        public SizeDto Size { get; set; }
    }
}

