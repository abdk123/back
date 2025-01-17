﻿using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Invoises.Dto;

namespace Souccar.SaleManagement.Receives.Dto
{
    public class ReceivingItemDto : EntityDto
    {
        public string MaterialName => InvoiceItem?.OfferItem?.Material?.Name;
        public double ReceivedQuantity { get; set; }
        public int? InvoiceItemId { get; set; }
        public InvoiceItemDto InvoiceItem { get; set; }
    }
}
