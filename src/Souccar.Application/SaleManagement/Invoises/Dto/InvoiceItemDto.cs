﻿using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Offers.Dto;

namespace Souccar.SaleManagement.Invoises.Dto
{
    public class InvoiceItemDto : EntityDto
    {
        public double Quantity { get; set; }
        public double TotalMaterilPrice { get; set; }
        public double ReceivedQuantity { get; set; }
        public double NumberInSmallUnit { get; set; }
        public OfferItemDto OfferItem { get; set; }
        public int? OfferItemId { get; set; }
        

    }
}
