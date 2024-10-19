using Abp.Application.Services.Dto;
using Souccar.Core.Includes;
using Souccar.Core.Search;

namespace Souccar.Core.ResultRequests
{
    public class CorePagedRequestDto: PagedResultRequestDto, ISortedResultRequest, IIncludeResultRequest, ISearchResultRequest 
    {
        public string Including { get; set; }
        public string Sorting { get; set; }
        public string Keyword { get; set; }
    }
}
