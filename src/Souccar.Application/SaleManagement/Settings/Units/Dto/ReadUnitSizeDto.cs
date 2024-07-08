using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Units.Dto
{
   public class ReadUnitSizeDto : EntityDto<int>
    {
        public int count { get; set; }
        public int? sizeId { get; set; }
        public int? unitId { get; set; }
    }
}

