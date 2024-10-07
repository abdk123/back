using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Currencies;

namespace Souccar.SaleManagement.SupplierOffers.Dto
{
   public class CreateSupplierOfferDto : EntityDto<int>
    {
        public CreateSupplierOfferDto()
        {
            OfferItems = new List<CreateSupplierOfferItemDto>();
        }
        public DateTime? OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? SupplierId { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string PorchaseOrderId { get; set; }
        public IList<CreateSupplierOfferItemDto> OfferItems { get; set; }
    }
}
