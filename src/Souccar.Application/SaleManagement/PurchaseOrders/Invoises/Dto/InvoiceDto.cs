using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Dto
{
   public class InvoiceDto : EntityDto<int>
    {
        public int Status { get; set; }
        public int? OfferId { get; set; }
    }
}

