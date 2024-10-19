using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class PagedDeliveryResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

