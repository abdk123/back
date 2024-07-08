using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Stocks.Dto
{
   public class PagedStockResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

