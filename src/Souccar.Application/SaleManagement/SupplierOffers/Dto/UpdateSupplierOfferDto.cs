using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.SupplierOffers.Dto
{
   public class UpdateSupplierOfferDto : EntityDto<int>
    {
        public UpdateSupplierOfferDto()
        {
            SupplierOfferItems = new List<UpdateSupplierOfferItemDto>();
        }
        public string OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? SupplierId { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string PorchaseOrderId { get; set; }
        public IList<UpdateSupplierOfferItemDto> SupplierOfferItems { get; set; }
    }
}

