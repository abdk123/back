using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Offers.Dto
{
   public class CreateOfferDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}

