using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Categories.Dto
{
   public class PagedCategoryResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

