using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Stores.Dto
{
   public class PagedStoreResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

