using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Dto
{
   public class PagedClearanceCompanyVoucherResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

