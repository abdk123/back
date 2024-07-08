using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Dto
{
   public class UpdateMaterialDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Specification { get; set; }
        public int? CategoryId { get; set; }
    }
}

