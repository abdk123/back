using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Dto
{
   public class PagedMaterialResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

