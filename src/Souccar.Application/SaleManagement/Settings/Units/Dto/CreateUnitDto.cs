using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Units.Dto
{
   public class CreateUnitDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}

