using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
   public class UpdateOfferDto : EntityDto<int>
    {
        public string PorchaseOrderId { get; set; }
        public string OrderNumber { get; set; }
        public int Status { get; set; }
        public DateTime? OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
    }
}

