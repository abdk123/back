using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Currencies;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
   public class CreateOfferDto : EntityDto<int>
    {
        public CreateOfferDto()
        {
            OfferItems = new List<CreateOfferItemDto>();
        }
        public string OrderNumber { get; set; }
        public DateTime? OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? CustomerId { get; set; }
        public IList<CreateOfferItemDto> OfferItems { get; set; }
    }
}

