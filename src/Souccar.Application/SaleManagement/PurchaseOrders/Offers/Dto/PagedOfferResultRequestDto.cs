using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
   public class PagedOfferResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

