using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.SupplierOffers.Dto
{
    public class CreateSupplierOfferDto : EntityDto<int>
    {
        public CreateSupplierOfferDto()
        {
            SupplierOfferItems = new List<CreateSupplierOfferItemDto>();
        }
        public DateTime? SupplierOfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? SupplierId { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string PorchaseOrderId { get; set; }
        public IList<CreateSupplierOfferItemDto> SupplierOfferItems { get; set; }
    }
}

