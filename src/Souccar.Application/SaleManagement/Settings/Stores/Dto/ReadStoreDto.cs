using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Stores.Dto
{
   public class ReadStoreDto : EntityDto<int>
    {
        public string name { get; set; }
        public string address { get; set; }
        public string description { get; set; }
    }
}

