using System;
using Abp.Application.Services.Dto;

namespace Souccar.Hr.Employees.Dto
{
   public class PagedEmployeeResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

