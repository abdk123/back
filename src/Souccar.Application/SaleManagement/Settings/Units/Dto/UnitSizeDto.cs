using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Units.Dto
{
   public class UnitSizeDto : EntityDto<int>
    {
        public int Count { get; set; }
        public int? SizeId { get; set; }
        public int? UnitId { get; set; }
    }
}

