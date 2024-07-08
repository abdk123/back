using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Stores.Dto
{
   public class UpdateStoreDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}

