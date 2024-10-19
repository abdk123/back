using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Receives.Dto
{
    public class PagedReceivingResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

