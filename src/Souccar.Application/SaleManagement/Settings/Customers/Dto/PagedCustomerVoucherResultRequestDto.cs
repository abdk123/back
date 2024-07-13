using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Dto
{
   public class PagedCustomerVoucherResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

