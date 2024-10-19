using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Offers.Dto
{
    public class UpdateOfferDto : EntityDto<int>
    {
        public UpdateOfferDto()
        {
            OfferItems = new List<UpdateOfferItemDto>();
        }
        public string OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? CustomerId { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string PorchaseOrderId { get; set; }
        public IList<UpdateOfferItemDto> OfferItems { get; set; }
    }
}

