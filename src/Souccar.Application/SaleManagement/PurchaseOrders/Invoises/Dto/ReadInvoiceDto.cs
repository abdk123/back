using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Dto
{
   public class ReadInvoiceDto : EntityDto<int>
    {
        public int status { get; set; }
        public int? offerId { get; set; }
    }
}

