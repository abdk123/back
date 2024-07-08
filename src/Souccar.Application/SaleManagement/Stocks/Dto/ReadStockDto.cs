using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Stocks.Dto
{
   public class ReadStockDto : EntityDto<int>
    {
        public string barcode { get; set; }
        public string note { get; set; }
        public double count { get; set; }
        public double numberInLargeUnit { get; set; }
        public double numberInSmallUnit { get; set; }
        public double quantityInLargeUnit { get; set; }
        public double totalNumberInSmallUnit { get; set; }
        public int? unitId { get; set; }
        public int? sizeId { get; set; }
        public int? materialId { get; set; }
        public int? storeId { get; set; }
    }
}

