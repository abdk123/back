using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Units.Dto
{
   public class CreateSizeDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}

