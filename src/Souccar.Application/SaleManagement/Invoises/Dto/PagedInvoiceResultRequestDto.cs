using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Invoises.Dto
{
    public class PagedInvoiceResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

