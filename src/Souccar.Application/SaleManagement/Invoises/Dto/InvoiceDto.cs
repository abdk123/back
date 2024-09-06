using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Invoises.Dto
{
    public class InvoiceDto : EntityDto<int>
    {
        public int Status { get; set; }
        public string PoNumber { get; set; }
        public int Currency { get; set; }
        public int? OfferId { get; set; }
        public DateTime? OfferDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime CreationTime { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public string SupplierName { get; set; }
        public double TotalReceivedQuantity { get; set; }
        public double TotalNotReceivedQuantity => TotalQuantity - TotalReceivedQuantity;
        public IList<InvoiceItemDto> InvoiseDetails { get; set; }
    }
}

