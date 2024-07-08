using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Categories.Dto
{
   public class ReadCategoryDto : EntityDto<int>
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}

