using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;

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
        public string SupplierId { get; set; }
        public string CreatorUser { get; set; }
        public double TotalReceivedQuantity => InvoiseDetails.Any() ? InvoiseDetails.Sum(x=>x.ReceivedQuantity) : 0;
        public double TotalNotReceivedQuantity => TotalQuantity - TotalReceivedQuantity;
        public IList<InvoiceItemDto> InvoiseDetails { get; set; }
        //public IList<ReceivingDto> Receivings { get; set; }
    }
}

