using Souccar.Core.Search;

namespace Souccar.Core.Dto.PagedRequests
{
    public class SearchPagedRequestDto: SortingPagedRequestDto, ISearchResultRequest
    {
        public string Keyword { get; set; }
    }
}
