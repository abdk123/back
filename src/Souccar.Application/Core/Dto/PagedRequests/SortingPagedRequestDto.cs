using Abp.Application.Services.Dto;

namespace Souccar.Core.Dto.PagedRequests
{
    public class SortingPagedRequestDto: PagedResultRequestDto, ISortedResultRequest
    {
        /// <summary>
        /// FirstName desc,LastName
        /// </summary>
        public string Sorting { get; set; }
    }
}
