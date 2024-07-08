using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Units.Dto
{
   public class UpdateUnitDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}

