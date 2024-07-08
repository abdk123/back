using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Dto
{
   public class ReadMaterialDto : EntityDto<int>
    {
        public string name { get; set; }
        public string specification { get; set; }
        public int? categoryId { get; set; }
    }
}

