using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Categories.Dto
{
   public class CreateCategoryDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

