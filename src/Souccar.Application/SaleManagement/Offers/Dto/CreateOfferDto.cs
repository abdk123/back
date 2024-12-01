using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Offers.Dto
{
    public class CreateOfferDto : EntityDto<int>
    {
        public CreateOfferDto()
        {
            OfferItems = new List<CreateOfferItemDto>();
        }
        public DateTime? OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? CustomerId { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string PorchaseOrderId { get; set; }
        public IList<CreateOfferItemDto> OfferItems { get; set; }
    }
}

