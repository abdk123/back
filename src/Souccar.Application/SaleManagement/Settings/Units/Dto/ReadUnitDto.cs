using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Units.Dto
{
   public class ReadUnitDto : EntityDto<int>
    {
        public string name { get; set; }
    }
}

