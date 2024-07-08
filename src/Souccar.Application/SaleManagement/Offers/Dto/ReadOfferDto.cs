using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Offers.Dto
{
   public class ReadOfferDto : EntityDto<int>
    {
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}

