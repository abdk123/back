using System;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Categories.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Dto
{
   public class MaterialDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Specification { get; set; }
        public int? CategoryId { get; set; }
        public CategoryForDropdownDto Category { get; set; }
    }
}

