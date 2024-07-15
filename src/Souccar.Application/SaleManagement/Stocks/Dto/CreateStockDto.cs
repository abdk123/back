using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Stocks.Dto
{
   public class CreateStockDto : EntityDto<int>
    {
        public string Barcode { get; set; }
        public string Note { get; set; }
        public double Count { get; set; }
        public double NumberInLargeUnit { get; set; }
        public double NumberInSmallUnit { get; set; }
        public int? UnitId { get; set; }
        public int? SizeId { get; set; }
        public int? MaterialId { get; set; }
        public int? StoreId { get; set; }
    }
}

