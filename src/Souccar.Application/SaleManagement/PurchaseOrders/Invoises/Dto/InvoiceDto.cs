using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Dto
{
    public class InvoiceDto : EntityDto<int>
    {
        public int Status { get; set; }
        public string SupplierName { get; set; }
        public string PoNumber { get; set; }
        public int Currency { get; set; }
        public int? OfferId { get; set; }
        public DateTime? OfferDate { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public IList<InvoiceItemDto> InvoiseDetails { get; set; }
    }
}

